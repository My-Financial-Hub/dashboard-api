using FinancialHub.Dashboards.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialHub.Dashboards.Infra.Data.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDashboardDatabase(this IServiceCollection services)
        {
            var configuration = GetConfiguration();
            services
                .AddDatabase(configuration)
                .AddDatabaseHealthCheck();

            return services;
        }

        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile(
                    path: "dashboards.database.appsettings.json",
                    optional: false,
                    reloadOnChange: true
                )
                .Build();
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DashboardContext>(
                provider =>
                {
                    provider.UseSqlServer(
                        configuration.GetConnectionString("Dashboard"),
                        x => x.MigrationsHistoryTable("migrations")
                    );
                }
            );
            return services;
        }

        private static IServiceCollection AddDatabaseHealthCheck(this IServiceCollection services)
        {
            services
               .AddHealthChecks()
               .AddDbContextCheck<DashboardContext>("Dashboard Database");

            return services;
        }
    }
}
