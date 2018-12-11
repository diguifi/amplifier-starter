using Amplifier.AspNetCore.Auditing;
using Amplifier.AspNetCore.Entities;
using Amplifier.AspNetCore.MultiTenancy;
using Microsoft.AspNetCore.Identity;

namespace AmplifierApiSample.Domain.Authentication
{
    public class Role : IdentityRole<int>, IEntity<int>, IMayHaveTenant, ITenantFilter, IFullAuditedEntity, ISoftDelete
    {

    }
}
