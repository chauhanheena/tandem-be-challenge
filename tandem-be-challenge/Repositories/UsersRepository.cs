using tandem_be_challenge.Configs.CosmosDB;
using tandem_be_challenge.Entities;

namespace tandem_be_challenge.Repositories.Impl
{
    public class UsersRepository : IUsersRepository
    {
        private readonly CosmosConfigService cosmosConfigService;

        public UsersRepository(CosmosConfigService cosmosConfigService)
        {
            this.cosmosConfigService = cosmosConfigService;
        }

        public async Task<UserEntity> CreateUser(UserEntity entity)
        {
            UserEntity? response = await cosmosConfigService.AddItemAsync(entity);
            return response;
        }

        public async Task<UserEntity> GetUserByEmailAddress(string emailAddress)
        {
            return await cosmosConfigService.GetItemAsyncById(emailAddress);
        }
    }
}
