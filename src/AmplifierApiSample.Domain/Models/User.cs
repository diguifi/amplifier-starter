using Amplifier.AspNetCore.Auditing;
using Amplifier.AspNetCore.Entities;
using Amplifier.AspNetCore.MultiTenancy;
using Microsoft.AspNetCore.Identity;

namespace AmplifierApiSample.Domain.Models
{
    public class User : IdentityUser<int>, IEntity<int>, IMayHaveTenant, ITenantFilter, IFullAuditedEntity, ISoftDelete
    {
        public string Name { get; set; }
    }
}
