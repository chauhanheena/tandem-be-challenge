using AutoMapper;
using MediatR;
using tandem_be_challenge.DTOs;
using tandem_be_challenge.Entities;
using tandem_be_challenge.Queries;
using tandem_be_challenge.Repositories;

namespace tandem_be_challenge.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserResponseDTO>
    {
        private readonly IUsersRepository usersRepository;
        private readonly IMapper Mapper;

        public GetUserQueryHandler(IUsersRepository usersRepository, IMapper Mapper)
        {
            this.usersRepository = usersRepository;
            this.Mapper = Mapper;
        }

        public async Task<UserResponseDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            UserEntity user = await usersRepository.GetUserByEmailAddress(request.emailAddress);
            return this.Mapper.Map<UserResponseDTO>(user);
        }
    }
}
