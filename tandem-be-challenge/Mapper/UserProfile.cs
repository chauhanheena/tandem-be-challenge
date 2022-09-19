using AutoMapper;
using tandem_be_challenge.DTOs;
using tandem_be_challenge.Entities;

namespace tandem_be_challenge.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequestDTO, UserEntity>().ForMember(user => user.EmailAddressId,
                opt => opt.MapFrom(user => user.EmailAddress));

            CreateMap<UserEntity, UserResponseDTO>()
                .ForMember(user => user.UserId, opt => opt.MapFrom(entity => entity.Id))
                .ForMember(user => user.Name, opt => opt.MapFrom(entity => string.Format("{0} {1} {2}",
                entity.FirstName, entity.MiddleName, entity.LastName)));
        }
    }
}
