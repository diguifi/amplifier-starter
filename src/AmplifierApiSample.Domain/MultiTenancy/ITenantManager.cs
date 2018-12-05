using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmplifierApiSample.Domain.MultiTenancy
{
    public interface ITenantManager
    {
        Task<int> Create(Tenant tenant);
        Task Delete(int id);
        Task<List<Tenant>> GetAll();
        Task<Tenant> GetById(int id);
        Task<Tenant> Update(Tenant tenant);
    }
}