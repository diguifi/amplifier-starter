using Amplifier.AspNetCore.Authentication;
using AmplifierStarter.Application.MultiTenancy;
using AmplifierStarter.Application.MultiTenancy.Dto;
using AmplifierStarter.Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmplifierStarter.WebApi.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantAppService _tenantAppService;
        private readonly IUserManager _userManager;
        private readonly IUserSession<int> _userSession;

        public TenantsController(ITenantAppService tenantAppService,
                                 IUserManager userManager,
                                 IUserSession<int> userSession)
        {
            _tenantAppService = tenantAppService;
            _userManager = userManager;
            _userSession = userSession;
        }

        // GET: api/Tenants
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            IList<TenantDto> tenants = await _tenantAppService.GetAll();

            if (tenants.Count <= 0)
            {
                return NotFound("No Tenants found.");
            }

            return Ok(tenants);            
        }

        // GET: api/Tenants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TenantDto tenant = await _tenantAppService.GetById(id);
            if (tenant == null)
            {
                return NotFound("Tenant not found.");                
            }

            return Ok(tenant);
        }

        // POST: api/Tenants
        [HttpPost]
        public async Task<IActionResult> Post(TenantDto tenantDto)
        {
            try
            {
                await _tenantAppService.Create(tenantDto);                
                return Ok(new { Mensagem = "Tenant created successfully" });
            }
            catch (Exception ex)
            {                
                return Conflict("Error in Tenant creation." + ex.Message);
            }            
        }

        // PUT: api/Tenants/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(TenantDto tenantDto)
        {
            try
            {
                TenantDto updatedTenant = await _tenantAppService.Update(tenantDto);

                if (updatedTenant == null)
                {
                    return NotFound("Tenant not found.");
                }

                return Ok(updatedTenant);
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
            TenantDto tenant = await _tenantAppService.GetById(id);
            if (tenant == null)
            {
                return NotFound("Tenant not found.");
            }

            try
            {
                await _tenantAppService.Delete(id);
                return Ok("Tenant deleted successfully.");
            }
            catch (Exception ex)
            {
                return Conflict("Error deleting the Tenant. " + ex.Message);
            }                        
        }
    }
}
