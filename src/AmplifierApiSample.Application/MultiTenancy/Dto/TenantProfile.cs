using AmplifierStarter.Domain.MultiTenancy;
using AutoMapper;

namespace AmplifierStarter.Application.MultiTenancy.Dto
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<Tenant, TenantDto>().ReverseMap();
        }
    }
}
