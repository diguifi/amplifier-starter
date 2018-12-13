using System.Collections.Generic;
using System.Threading.Tasks;
using AmplifierApiSample.Application.MultiTenancy.Dto;
using AmplifierApiSample.Domain.MultiTenancy;

namespace AmplifierApiSample.Application.MultiTenancy
{
    public interface ITenantAppService
    {
        Task<int> Create(Tenant tenant);
        Task Delete(int id);
        Task<IList<TenantDto>> GetAll();
        Task<TenantDto> GetById(int id);
        Task<TenantDto> Update(Tenant tenant);
    }
}