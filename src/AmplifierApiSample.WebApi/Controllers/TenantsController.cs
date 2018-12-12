using Amplifier.AspNetCore.Authentication;
using AmplifierApiSample.Domain.Authorization;
using AmplifierApiSample.Domain.MultiTenancy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AmplifierApiSample.WebApi.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantManager _tenantManager;
        private readonly IUserManager _userManager;
        private readonly IUserSession<int?> _userSession;

        public TenantsController(ITenantManager tenantManager, IUserManager userManager, IUserSession<int?> userSession)
        {
            _tenantManager = tenantManager;
            _userManager = userManager;
            _userSession = userSession;
        }

        // GET: api/Tenants
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var tenants = await _tenantManager.GetAll();
            if (tenants.Count > 0)
            {
                return Ok(tenants);
            }

            return NotFound("No Tenants found.");
        }

        // GET: api/Tenants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var tenant = await _tenantManager.GetById(id);
            if (tenant != null)
            {
                return Ok(tenant);
            }

            return NotFound("Tenant not found.");
        }

        // POST: api/Tenants
        [HttpPost]
        public async Task<IActionResult> Post(Tenant tenant)
        {
            try
            {
                int tenantId = await _tenantManager.Create(tenant);
                _userSession.TenantId = tenantId;
            }
            catch (Exception ex)
            {                
                return Conflict("Error in Tenant creation." + ex.Message);
            }

            try
            {
                var result = await _userManager.CreateAsync(new User
                {
                    Id = 0,
                    UserName = "admin" + "-" + _userSession.TenantId.ToString(),
                    Email = tenant.Email,
                    EmailConfirmed = true,
                }, "123@Qwe");

                return Ok(new { Mensagem = "Tenant created successfully" });
            }
            catch (Exception ex)
            {
                return Conflict("Error in Tenant creation." + ex.Message);
            }
        }

        // PUT: api/Tenants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Tenant tenant)
        {
            try
            {
                var tenantAtualizada = await _tenantManager.Update(tenant);

                if (tenantAtualizada == null)
                {
                    return NotFound("Tenant not found.");
                }

                return Ok(tenantAtualizada);
            }
            catch (Exception ex)
            {
                return Conflict("Error updating the Tenant. " + ex.Message);
            }                       
        }

        // DELETE: api/Tenants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tenant = _tenantManager.GetById(id);
            if (tenant == null)
            {
                return NotFound("Tenant not found.");
            }

            try
            {
                await _tenantManager.Delete(id);
                return Ok("Tenant deleted successfully.");
            }
            catch (Exception ex)
            {
                return Conflict("Error deleting the Tenant. " + ex.Message);
            }                        
        }
    }
}
