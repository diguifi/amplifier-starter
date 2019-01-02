using Amplifier.AspNetCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmplifierStarter.Domain.MultiTenancy
{
    public class TenantManager : ITenantManager
    {
        private readonly IRepositoryBase<Tenant, int> _tenantRepository;

        public TenantManager(IRepositoryBase<Tenant, int> tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<int> Create(Tenant tenant)
        {
            return await _tenantRepository.Create(tenant);
        }

        public async Task<Tenant> Update(Tenant tenant)
        {
            return await _tenantRepository.Update(tenant);
        }

        public async Task<Tenant> GetById(int id)
        {
            return await _tenantRepository.GetById(id);
        }

        public async Task<List<Tenant>> GetAll()
        {
            return await _tenantRepository.GetAll().ToListAsync();
        }

        public async Task Delete(int id)
        {
            await _tenantRepository.Delete(id);
        }
    }
}
