using AmplifierApiSample.Domain.MultiTenancy;
using AutoMapper;

namespace AmplifierApiSample.Application.MultiTenancy.Dto
{
    public class TenantProfile : Profile
    {
        public TenantProfile()
        {
            CreateMap<Tenant, TenantDto>().ReverseMap();
        }
    }
}
