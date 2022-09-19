using MediatR;
using tandem_be_challenge.DTOs;

namespace tandem_be_challenge.Commands
{
    public record CreateUserCommand(UserRequestDTO userRequestDTO) : IRequest<UserResponseDTO>;
}
