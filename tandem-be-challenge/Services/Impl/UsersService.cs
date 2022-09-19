using AutoMapper;
using tandem_be_challenge.DTOs;
using tandem_be_challenge.Entities;
using tandem_be_challenge.Repositories;

namespace tandem_be_challenge.Services.impl
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper mapper;

        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            this.usersRepository = usersRepository;
            this.mapper = mapper;
        }

        public async Task<UserResponseDTO> CreateUser(UserRequestDTO userRequestDTO)
        {
            UserEntity entity = mapper.Map<UserEntity>(userRequestDTO);
            UserEntity createdUser = await usersRepository.CreateUser(entity);
            return mapper.Map<UserResponseDTO>(createdUser);
        }

        public async Task<UserResponseDTO> GetUserByEmailAddress(string emailAddress)
        {
            UserEntity user = await usersRepository.GetUserByEmailAddress(emailAddress);
            return mapper.Map<UserResponseDTO>(user);
        }
    }
}
