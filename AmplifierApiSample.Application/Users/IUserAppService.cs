using System.Collections.Generic;
using System.Threading.Tasks;
using AmplifierApiSample.Application.Users.Dto;
using AmplifierApiSample.Domain.Authorization;
using Microsoft.AspNetCore.Identity;

namespace AmplifierApiSample.Application.Users
{
    public interface IUserAppService
    {
        Task<IdentityResult> Create(UserDto userDto, string password);
        Task<IdentityResult> Delete(int id);
        Task<IList<UserDto>> GetAll();
        Task<UserDto> GetById(int id);
        Task<IdentityResult> Update(UserDto userDto);
    }
}