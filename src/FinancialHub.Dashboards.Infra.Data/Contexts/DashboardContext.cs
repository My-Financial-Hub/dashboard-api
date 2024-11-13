using Microsoft.EntityFrameworkCore;

namespace FinancialHub.Dashboards.Infra.Data.Contexts
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DashboardContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
