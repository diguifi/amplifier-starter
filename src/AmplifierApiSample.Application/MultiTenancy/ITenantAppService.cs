using System.Collections.Generic;
using System.Threading.Tasks;
using AmplifierStarter.Application.MultiTenancy.Dto;
using AmplifierStarter.Domain.MultiTenancy;

namespace AmplifierStarter.Application.MultiTenancy
{
    public interface ITenantAppService
    {
        Task<int> Create(TenantDto tenantDto);
        Task Delete(int id);
        Task<IList<TenantDto>> GetAll();
        Task<TenantDto> GetById(int id);
        Task<TenantDto> Update(TenantDto tenantDto);
    }
}