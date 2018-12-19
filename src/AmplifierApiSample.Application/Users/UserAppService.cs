using Amplifier.AspNetCore.Authentication;
using AmplifierApiSample.Application.Users.Dto;
using AmplifierApiSample.Domain.Authorization;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmplifierApiSample.Application.Users
{
    public class UserAppService : IUserAppService
    {        
        private readonly IUserManager _userManager;
        private readonly IUserSession<int> _userSession;
        private readonly IMapper _mapper;

        public UserAppService(IUserManager userManager,
                              IUserSession<int> userSession,
                              IMapper mapper)
        {            
            _userManager = userManager;
            _userSession = userSession;
            _mapper = mapper;
        }

        public async Task<IList<UserDto>> GetAll()
        {
            IList<User> users = await _userManager.GetAllUsers();
            return _mapper.Map<IList<UserDto>>(users);
        }

        public async Task<UserDto> GetById(int id)
        {
            User user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IdentityResult> Create(UserDto userDto, string password)
        {
            return await _userManager.CreateAsync(_mapper.Map<User>(userDto), password);
        }

        public async Task<IdentityResult> Update(UserDto userDto)
        {
            return await _userManager.UpdateAsync(_mapper.Map<User>(userDto));
        }

        public async Task<IdentityResult> Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return await _userManager.DeleteAsync(user);
        }
    }
}
