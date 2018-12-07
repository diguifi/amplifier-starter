using AmplifierApiSample.Domain.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AmplifierApiSample.WebApi.Controllers
{
    public class UsersController :ControllerBase
    {
        private readonly IUserManager _userManager;

        public UsersController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.GetAllUsers();
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
            var user = await _userManager.GetUserById(id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound("User not found.");
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> CreateUser(User user, string password)
        {
            try
            {
                await _userManager.CreateUser(user, password);
                return Ok(new { Mensagem = "User created successfully" });
            }
            catch (Exception ex)
            {
                return Conflict("Error in User creation." + ex.Message);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            try
            {
                var result = await _userManager.UpdateUser(user);

                if (result == IdentityResult.Success)
                {
                    return NotFound("User not found.");
                }

                return Ok(user);
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
            var user = await _userManager.GetUserById(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            try
            {
                var result = await _userManager.DeleteUser(user);

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
