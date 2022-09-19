using Microsoft.Azure.Cosmos;
using tandem_be_challenge.Entities;
using tandem_be_challenge.Exceptions;

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
            try
            {
                return await this.container.CreateItemAsync(userEntity, new PartitionKey(userEntity.EmailAddress));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                throw new UserAlreadyExistsException("User already exists");
            }
            catch (Exception)
            {
                throw new InterenalServerException("Something went wrong");
            }
        }

        public async Task<UserEntity?> GetItemAsyncById(string emailId)
        {
            try
            {
                ItemResponse<UserEntity> response = await this.container
                .ReadItemAsync<UserEntity>(emailId, new PartitionKey(emailId));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new UserNotFoundException("User not found");
            }
            catch (Exception)
            {
                throw new InterenalServerException("Something went wrong");
            }
        }
    }
}
