using Microsoft.Azure.Cosmos;
using tandem_be_challenge.Entities;

namespace tandem_be_challenge.Configs.CosmosDB
{
    public class CosmosConfigService
    {
        private Container container;

        public CosmosConfigService(CosmosClient dbClient, string databaseName, string containerName)
        {
            container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task<UserEntity?> AddItemAsync(UserEntity userEntity)
        {
            return await this.container.CreateItemAsync<UserEntity>
                (userEntity, new PartitionKey(userEntity.EmailAddress));
        }
    }
}
