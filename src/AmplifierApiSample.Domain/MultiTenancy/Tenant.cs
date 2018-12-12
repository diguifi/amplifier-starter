using Amplifier.AspNetCore.Auditing;
using Amplifier.AspNetCore.MultiTenancy;

namespace AmplifierApiSample.Domain.MultiTenancy
{
    public class Tenant : TenantBase, IFullAuditedEntity, ISoftDelete
    {
        public string Email  { get; set; }
    }
}
