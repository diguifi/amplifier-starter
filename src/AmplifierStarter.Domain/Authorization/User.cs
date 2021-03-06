﻿using Amplifier.AspNetCore.Auditing;
using Amplifier.AspNetCore.Entities;
using Amplifier.AspNetCore.MultiTenancy;
using Microsoft.AspNetCore.Identity;

namespace AmplifierStarter.Domain.Authorization
{
    public class User : IdentityUser<int>, IEntity<int>, IMayHaveTenant, ITenantFilter, IFullAuditedEntity, ISoftDelete
    {        
    }
}
