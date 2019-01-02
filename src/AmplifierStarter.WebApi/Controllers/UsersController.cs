using AmplifierStarter.Application.Users;
using AmplifierStarter.Application.Users.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmplifierStarter.WebApi.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController :ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            IList<UserDto> users = await _userAppService.GetAll();
            if (users.Count > 0)
            {
                return Ok(users);
            }

            return NotFound("No Users found.");
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userAppService.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound("User not found.");
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto, string password)
        {
            try
            {
                await _userAppService.Create(userDto, password);
                return Ok(new { Mensagem = "User created successfully" });
            }
            catch (Exception ex)
            {
                return Conflict("Error in User creation." + ex.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            try
            {
                var result = await _userAppService.Update(userDto);

                if (result == IdentityResult.Success)
                {
                    return Ok(userDto);
                }

                return NotFound("User not found.");                
            }
            catch (Exception ex)
            {
                return Conflict("Error updating the User. " + ex.Message);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _userAppService.Delete(id);

                if (result == IdentityResult.Success)
                {
                    return Ok("User deleted successfully.");
                }

                return Conflict("Error deleting the User. " + result.Errors);
            }
            catch (Exception ex)
            {
                return Conflict("Error deleting the User. " + ex.Message);
            }
        }
    }
}
