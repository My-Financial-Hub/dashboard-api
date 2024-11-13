using FinancialHub.Dashboards.Api.Health.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;

namespace FinancialHub.Dashboards.Api.Health.Extensions
{
    public static class IEndpointRouteBuilderExtensions
    {
        public static void AddHealthCheckEndpoint(this IEndpointRouteBuilder app, string endpoint = "/health")
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(endpoint, nameof(endpoint));

            app.MapHealthChecks(endpoint, new HealthCheckOptions
            {
                ResponseWriter = ResponseWriter.Write
            });
        }
    }
}
