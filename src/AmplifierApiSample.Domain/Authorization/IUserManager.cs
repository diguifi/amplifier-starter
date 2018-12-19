using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AmplifierApiSample.Domain.Authorization
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> DeleteAsync(User user);
        Task<IList<User>> GetAllUsers();
        Task<User> FindByIdAsync(int id);
        Task<IdentityResult> UpdateAsync(User user);
        Task<User> FindByNameAsync(string userName);
        Task<bool> IsInRoleAsync(User user, string role);
        Task<IList<string>> GetRolesAsync(User user);
    }
}