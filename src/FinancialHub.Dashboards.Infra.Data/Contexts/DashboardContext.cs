using FinancialHub.Dashboards.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialHub.Dashboards.Infra.Data.Contexts
{
    public class DashboardContext : DbContext
    {
        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<BalanceEntity> Balances { get; set; }

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
