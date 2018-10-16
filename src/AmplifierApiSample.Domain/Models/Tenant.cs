using Amplifier.AspNetCore.Auditing;
using Amplifier.AspNetCore.MultiTenancy;

namespace AmplifierApiSample.Domain.Models
{
    public class Tenant : TenantBase<int>, IFullAuditedEntity, ISoftDelete
    {
    }
}
