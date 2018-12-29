using Amplifier.AspNetCore.Authentication;
using Amplifier.AspNetCore.Repositories;
using AmplifierStarter.Domain.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AmplifierStarter.Domain.Authorization
{
    public class LoginManager : ILoginManager
    {
        private readonly IRepositoryBase<Tenant, int> _tenantRepository;
        private readonly IUserSession<int> _userSession;
        private readonly IUserManager _userManager;
        private readonly SignInManager<User> _signInManager;

        public LoginManager(IRepositoryBase<Tenant, int> tenantRepository, 
                            IUserSession<int> userSession,
                            IUserManager userManager,
                            SignInManager<User> signInManager)
        {
            _tenantRepository = tenantRepository;
            _userSession = userSession;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResult> LoginAsync(LoginInfo login)
        {
            Tenant tenant = await _tenantRepository.GetAll().FirstOrDefaultAsync(t => t.Name == login.TenantName);

            if(tenant == null && login.TenantName != "host")
            {
                return new LoginResult
                {
                    User = null,
                    Message = "Login failed. Tenant not found.",
                    Succeeded = false
                };
            }

            if(tenant != null && !tenant.IsActive)
            {
                return new LoginResult
                {
                    User = null,
                    Message = "Login failed. Tenant is not active.",
                    Succeeded = false
                };
            }

            if (tenant != null)
            {
                _userSession.TenantId = tenant.Id;
            }

            if(!string.IsNullOrEmpty(login.UserId))
            {
                return await LoginInternalAsync(login);
            }

            return null;
        }

        private async Task<LoginResult> LoginInternalAsync(LoginInfo login)
        {
            User userIdentity = await _userManager.FindByNameAsync(login.UserId);

            if (userIdentity != null)
            {
                SignInResult signInResult = _signInManager.CheckPasswordSignInAsync(userIdentity, login.Password, false).Result;

                if (signInResult.Succeeded)
                {
                    return new LoginResult {
                        User = userIdentity,
                        Message = "Login Successfully.",
                        Succeeded = true
                    };
                }

                return new LoginResult
                {
                    User = null,
                    Message = "Login failed. Invalid Username or password.",
                    Succeeded = false
                };
            }

            return new LoginResult
            {
                User = null,
                Message = "Login failed. User not found",
                Succeeded = false
            };
        }        
    }
}
