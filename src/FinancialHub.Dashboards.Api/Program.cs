using FinancialHub.Dashboards.Infra.Data.Extensions;
using FinancialHub.Dashboards.Api.Health.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDashboardDatabase();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();
app.AddHealthCheckEndpoint("health");

app.Run();
