using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmplifierStarter.Domain.Authentication
{
    public class RoleManager : RoleManager<Role>, IRoleManager
    {
        public RoleManager(IRoleStore<Role> store,
                           IEnumerable<IRoleValidator<Role>> roleValidators,
                           ILookupNormalizer keyNormalizer,
                           IdentityErrorDescriber errors,
                           ILogger<RoleManager<Role>> logger)
                           : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }

        public async Task<IdentityResult> CreateRoleAsync(Role role)
        {
            return await CreateAsync(role);
        }

        public async Task<IdentityResult> UpdateUserAsync(Role role)
        {
            return await UpdateAsync(role);
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await GetRoleById(id);
        }

        public async Task<IList<Role>> GetAllRoles()
        {
            return await Roles.ToListAsync();
        }

        public async Task<IdentityResult> DeleteRoleAsync(Role role)
        {
            return await DeleteAsync(role);
        }
    }
}
