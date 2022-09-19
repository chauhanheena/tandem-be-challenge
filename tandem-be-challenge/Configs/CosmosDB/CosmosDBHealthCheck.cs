using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace tandem_be_challenge.Configs.CosmosDB
{
    public class CosmosDBHealthCheck : IHealthCheck
    {
        private readonly CosmosConfigService cosmosConfig;

        public CosmosDBHealthCheck(CosmosConfigService cosmosConfig)
        {
            this.cosmosConfig = cosmosConfig;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return await cosmosConfig.IsHealthy()
                ? await Task.FromResult(HealthCheckResult.Healthy())
                : await Task.FromResult(HealthCheckResult.Unhealthy());
        }
    }
}
