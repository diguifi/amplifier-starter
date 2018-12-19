using AmplifierApiSample.Domain.Authorization;
using AutoMapper;

namespace AmplifierApiSample.Application.Users.Dto
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
