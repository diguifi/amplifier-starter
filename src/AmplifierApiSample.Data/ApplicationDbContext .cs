using Amplifier.AspNetCore.Authentication;
using Amplifier.EntityFrameworkCore;
using AmplifierApiSample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AmplifierApiSample.Data
{
    public class ApplicationDbContext : DbContextBase<int>
    {
        private readonly IUserSession<int> _userSession;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserSession<int> userSession)
            : base(options, userSession)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }

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
