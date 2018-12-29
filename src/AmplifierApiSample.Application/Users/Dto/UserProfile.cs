using AmplifierStarter.Domain.Authorization;
using AutoMapper;

namespace AmplifierStarter.Application.Users.Dto
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
