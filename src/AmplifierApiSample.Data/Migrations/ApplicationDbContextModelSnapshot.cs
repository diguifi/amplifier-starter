﻿// <auto-generated />
using System;
using AmplifierStarter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AmplifierStarter.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.UserId", "'UserId', '', '2', '1', '', '', 'Int32', 'False'");

            modelBuilder.Entity("AmplifierStarter.Domain.Authentication.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreationTime");

                    b.Property<int?>("CreationUser");

                    b.Property<DateTime>("DeletionTime");

                    b.Property<int?>("DeletionUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModificationTime");

                    b.Property<int?>("LastModificationUser");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.Property<int?>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("CreationUser");

                    b.HasIndex("DeletionUser");

                    b.HasIndex("LastModificationUser");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.HasIndex("TenantId");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("AmplifierStarter.Domain.Authorization.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('\"UserId\"')");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreationTime");

                    b.Property<int?>("CreationUser");

                    b.Property<DateTime>("DeletionTime");

                    b.Property<int?>("DeletionUser");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModificationTime");

                    b.Property<int?>("LastModificationUser");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("TenantId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CreationUser");

                    b.HasIndex("DeletionUser");

                    b.HasIndex("LastModificationUser");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.HasIndex("TenantId");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "32fe9448-0c6c-43b2-b605-802c19c333a6",
                            CreationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreationUser = 1,
                            DeletionTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DeletionUser = 1,
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            IsDeleted = false,
                            LastModificationTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastModificationUser = 1,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEFesVxQc33USBjCj7gGC5PnbtdobLwKV0bgJ6GMCyG9a/c2y0dxEvc0zEBXUTvvb6A==",
                            PhoneNumber = "123",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "ce907fd5-ccb4-4e96-a7ea-45712a14f5ef",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("AmplifierStarter.Domain.MultiTenancy.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<int?>("CreationUser");

                    b.Property<DateTime>("DeletionTime");

                    b.Property<int?>("DeletionUser");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("Email");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModificationTime");

                    b.Property<int?>("LastModificationUser");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("CreationUser");

                    b.HasIndex("DeletionUser");

                    b.HasIndex("LastModificationUser");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AmplifierStarter.Domain.Authentication.Role", b =>
                {
                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("CreationUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("DeletionUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("LastModificationUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierStarter.Domain.MultiTenancy.Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AmplifierStarter.Domain.Authorization.User", b =>
                {
                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("CreationUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("DeletionUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("LastModificationUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierStarter.Domain.MultiTenancy.Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AmplifierStarter.Domain.MultiTenancy.Tenant", b =>
                {
                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("CreationUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("DeletionUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("LastModificationUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("AmplifierStarter.Domain.Authentication.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("AmplifierStarter.Domain.Authentication.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("AmplifierStarter.Domain.Authorization.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
