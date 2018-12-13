using Amplifier.AspNetCore.Authentication;
using AmplifierApiSample.Application.MultiTenancy.Dto;
using AmplifierApiSample.Domain.Authorization;
using AmplifierApiSample.Domain.MultiTenancy;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmplifierApiSample.Application.MultiTenancy
{
    public class TenantAppService : ITenantAppService
    {
        private readonly ITenantManager _tenantManager;
        private readonly IUserManager _userManager;
        private readonly IUserSession<int> _userSession;
        private readonly IMapper _mapper;

        public TenantAppService(ITenantManager tenantManager, 
                                IUserManager userManager,
                                IUserSession<int> userSession,
                                IMapper mapper)
        {
            _tenantManager = tenantManager;
            _userManager = userManager;
            _userSession = userSession;
            _mapper = mapper;
        }

        public async Task<IList<TenantDto>> GetAll()
        {
            IList<Tenant> tenants = await _tenantManager.GetAll();
            return _mapper.Map<IList<TenantDto>>(tenants);
        }

        public async Task<TenantDto> GetById(int id)
        {
            Tenant tenant = await _tenantManager.GetById(id);
            return _mapper.Map<TenantDto>(tenant);
        }

        public async Task<int> Create(Tenant tenant)
        {
            return await _tenantManager.Create(tenant);
        }

        public async Task<TenantDto> Update(Tenant tenant)
        {
            Tenant updatedTenant = await _tenantManager.Update(tenant);
            return _mapper.Map<TenantDto>(updatedTenant);
        }

        public async Task Delete(int id)
        {
            await _tenantManager.Delete(id);
        }
    }
}
