using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AmplifierApiSample.Domain.Authorization
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateUser(User user, string password);
        Task<IdentityResult> DeleteUser(User user);
        Task<IList<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<IdentityResult> UpdateUser(User user);
    }
}