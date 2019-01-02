using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AmplifierStarter.Domain.Authentication
{
    public interface IRoleManager
    {
        Task<IdentityResult> CreateRoleAsync(Role role);
        Task<IdentityResult> DeleteRoleAsync(Role role);
        Task<IList<Role>> GetAllRoles();
        Task<Role> GetRoleById(int id);
        Task<IdentityResult> UpdateUserAsync(Role role);
    }
}