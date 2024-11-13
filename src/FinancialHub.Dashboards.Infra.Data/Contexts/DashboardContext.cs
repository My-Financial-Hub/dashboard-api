﻿using Microsoft.EntityFrameworkCore;

namespace FinancialHub.Dashboards.Infra.Data.Contexts
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions options) : base(options)
        {
        }
    }
}