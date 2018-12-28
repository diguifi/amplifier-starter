using Amplifier.AspNetCore.Authentication;
using Amplifier.EntityFrameworkCore;
using Amplifier.EntityFrameworkCore.Identity;
using AmplifierApiSample.Domain.Authentication;
using AmplifierApiSample.Domain.Authorization;
using AmplifierApiSample.Domain.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AmplifierApiSample.Data
{
    public class ApplicationDbContext : IdentityDbContextBase<Tenant, User, Role, int>
    {
        private readonly IUserSession<int> _userSession;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserSession<int> userSession)
            : base(options, userSession)
        {
            _userSession = userSession;
        }

        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Role> ApplicationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();
            base.OnModelCreating(modelBuilder);
            SeedDataBase(modelBuilder);
        }

        private void SeedDataBase(ModelBuilder modelBuilder)
        {                        
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123@Qwe"),                
                CreationTime = DateTime.MinValue,
                AccessFailedCount = 0,
                CreationUser = 1,
                DeletionTime = DateTime.MinValue,
                DeletionUser = 1,
                IsDeleted = false,
                LastModificationTime = DateTime.MinValue,
                LastModificationUser = 1,
                LockoutEnabled = false,
                
                TermsOfServiceAccepted = true,
                TermsOfServiceAcceptedTimestamp = new DateTime(2018, 3, 24, 7, 42, 35, 10, DateTimeKind.Utc),
                SecurityStamp = "ce907fd5-ccb4-4e96-a7ea-45712a14f5ef",
                ConcurrencyStamp = "32fe9448-0c6c-43b2-b605-802c19c333a6",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                PhoneNumber = "123",
            });

            modelBuilder.HasSequence<int>("UserId")
                .StartsAt(2)
                .IncrementsBy(1);

            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .HasDefaultValueSql("nextval('\"UserId\"')");
        }
    }
}
