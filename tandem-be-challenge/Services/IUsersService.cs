using tandem_be_challenge.DTOs;

namespace tandem_be_challenge.Services
{
    public interface IUsersService
    {
        Task<UserResponseDTO> CreateUser(UserRequestDTO userRequestDTO);
    }
}
