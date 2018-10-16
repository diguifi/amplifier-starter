using Amplifier.AspNetCore.Auditing;
using Amplifier.AspNetCore.Entities;
using Amplifier.AspNetCore.MultiTenancy;

namespace AmplifierApiSample.Domain.Models
{
    public class User : IEntity<int>, IMayHaveTenant, ITenantFilter, IFullAuditedEntity, ISoftDelete
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
