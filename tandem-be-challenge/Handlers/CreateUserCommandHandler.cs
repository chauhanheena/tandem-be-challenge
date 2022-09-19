using AutoMapper;
using MediatR;
using tandem_be_challenge.Commands;
using tandem_be_challenge.DTOs;
using tandem_be_challenge.Entities;
using tandem_be_challenge.Exceptions;
using tandem_be_challenge.Repositories;

namespace tandem_be_challenge.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserResponseDTO>
    {
        private readonly IUsersRepository repository;
        private readonly IMapper mapper;

        public CreateUserCommandHandler(IUsersRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<UserResponseDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UserEntity entity = mapper.Map<UserEntity>(request.userRequestDTO);
                UserEntity createdUser = await repository.CreateUser(entity);
                return mapper.Map<UserResponseDTO>(createdUser);
            }
            catch (UserAlreadyExistsException ex)
            {
                throw ex;
            }
            catch (InternalServerException ex)
            {
                throw ex;
            }
        }
    }
}
