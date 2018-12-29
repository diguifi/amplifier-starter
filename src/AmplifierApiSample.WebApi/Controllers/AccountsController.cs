using Amplifier.AspNetCore.Authentication;
using AmplifierStarter.Data;
using AmplifierStarter.Domain.Authorization;
using AmplifierStarter.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace AmplifierStarter.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserSession< int> _userSession;
        private readonly ApplicationDbContext _context;
        private readonly IUserManager _userManager;
        private readonly ILoginManager _loginManager;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly SigningConfigurations _signingConfigurations;

        public AccountsController(IUserSession<int> userSession,
                                  ApplicationDbContext context,
                                  IUserManager userManager,
                                  ILoginManager loginManager,
                                  TokenConfigurations tokenConfigurations,
                                  SigningConfigurations signingConfigurations)
        {
            _userSession = userSession;
            _context = context;
            _userManager = userManager;
            _loginManager = loginManager;
            _tokenConfigurations = tokenConfigurations;
            _signingConfigurations = signingConfigurations;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Post([FromBody] LoginModel user)
        {
            var loginInfo = new LoginInfo
            {
                Password = user.Password,
                TenantName = user.TenantName,
                UserId = user.UserId
            };


            LoginResult loginResult = await _loginManager.LoginAsync(loginInfo);

            if(loginResult.Succeeded)
            {
                var token = await GenerateToken(loginResult.User);
                return Ok(token);
            }

            return StatusCode((int)HttpStatusCode.UnprocessableEntity, loginResult.Message);
        }
        
        private async Task<object> GenerateToken(User user)
        {
            _userSession.DisableTenantFilter = false;
            _userSession.UserId = user.Id;
            _userSession.UserName = user.UserName;
            _userSession.TenantId = (int?)_context.Entry(user).Property("TenantId").CurrentValue;

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim("userid",_userSession.UserId.ToString(), ClaimValueTypes.Integer),
                        new Claim("username",_userSession.UserName, ClaimValueTypes.String),
                        new Claim("tenantid",_userSession.TenantId.ToString(), ClaimValueTypes.Integer),
                }
            );

            IList<string> userRolesList = await _userManager.GetRolesAsync(user);
            if (userRolesList.Any())
            {
                identity.AddClaims(userRolesList.Select(rn => new Claim("roles", rn, ClaimValueTypes.String)));
            }

            DateTime creationDate = DateTime.Now;
            DateTime expirationDate = creationDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = creationDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = creationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK",
            };
        }
    }
}
