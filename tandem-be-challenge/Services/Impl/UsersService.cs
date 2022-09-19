using MediatR;
using tandem_be_challenge.Commands;
using tandem_be_challenge.DTOs;
using tandem_be_challenge.Queries;

namespace tandem_be_challenge.Services.impl
{
    public class UsersService : IUsersService
    {
        private readonly IMediator meadiator;

        public UsersService(IMediator meadiator)
        {
            this.meadiator = meadiator;
        }

        public async Task<UserResponseDTO> CreateUser(UserRequestDTO userRequestDTO)
        {
            return await meadiator.Send(new CreateUserCommand(userRequestDTO));
        }

        public async Task<UserResponseDTO> GetUserByEmailAddress(string emailAddress)
        {
            return await meadiator.Send(new GetUserQuery(emailAddress));
        }
    }
}
