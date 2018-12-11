using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmplifierApiSample.Domain.Authorization
{
    public class UserManager : UserManager<User>, IUserManager
    {
        public UserManager(
            IUserStore<User> userStore,
            IOptions<IdentityOptions> options,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer lookupNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger)
            : base(userStore, options, passwordHasher, userValidators, passwordValidators, lookupNormalizer, errors, services, logger)
        {

        }

        public async Task<IList<User>> GetAllUsers()
        {
            return await Users.ToListAsync();            
        }
    }
}
