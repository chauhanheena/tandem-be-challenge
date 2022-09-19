using tandem_be_challenge.Entities;

namespace tandem_be_challenge.Repositories
{
    public interface IUsersRepository
    {
        public Task<UserEntity> CreateUser(UserEntity entity);
    }
}
