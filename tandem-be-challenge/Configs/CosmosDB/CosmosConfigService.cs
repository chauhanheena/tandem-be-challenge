using Microsoft.Azure.Cosmos;

namespace tandem_be_challenge.Configs.CosmosDB
{
    public class CosmosConfigService
    {
        private Container container;

        public CosmosConfigService(CosmosClient dbClient, string databaseName, string containerName)
        {
            container = dbClient.GetContainer(databaseName, containerName);
        }
    }
}
