using Amplifier.AspNetCore.Authentication;
using Amplifier.EntityFrameworkCore;
using Amplifier.EntityFrameworkCore.Identity;
using AmplifierApiSample.Domain.Authorization;
using AmplifierApiSample.Domain.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AmplifierApiSample.Data
{
    public class ApplicationDbContext : IdentityDbContextBase<int, User, IdentityRole<int>, int>
    {
        private readonly IUserSession<int> _userSession;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserSession<int> userSession)
            : base(options, userSession)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        new public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var entities = builder.Model.GetEntityTypes().ToList();
            builder.MultiTenancy<Tenant>(entities);
            builder.Auditing<User, int>(entities);
            EnableTenantAndSoftDeleteFilters(builder, entities);
            base.OnModelCreating(builder);            
        }
    }
}
