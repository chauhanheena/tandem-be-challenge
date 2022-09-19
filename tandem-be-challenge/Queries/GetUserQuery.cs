using MediatR;
using tandem_be_challenge.DTOs;

namespace tandem_be_challenge.Queries
{
    public record GetUserQuery(string emailAddress) : IRequest<UserResponseDTO>;
}
