﻿// <auto-generated />
using System;
using AmplifierApiSample.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AmplifierApiSample.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AmplifierApiSample.Domain.Models.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("CreationUser");

                    b.Property<DateTime>("DeletionTime");

                    b.Property<int>("DeletionUser");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModificationTime");

                    b.Property<int>("LastModificationUser");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.HasIndex("CreationUser");

                    b.HasIndex("DeletionUser");

                    b.HasIndex("LastModificationUser");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("AmplifierApiSample.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationTime");

                    b.Property<int>("CreationUser");

                    b.Property<DateTime>("DeletionTime");

                    b.Property<int>("DeletionUser");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModificationTime");

                    b.Property<int>("LastModificationUser");

                    b.Property<string>("Name");

                    b.Property<int?>("TenantId");

                    b.HasKey("Id");

                    b.HasIndex("CreationUser");

                    b.HasIndex("DeletionUser");

                    b.HasIndex("LastModificationUser");

                    b.HasIndex("TenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AmplifierApiSample.Domain.Models.Tenant", b =>
                {
                    b.HasOne("AmplifierApiSample.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("CreationUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierApiSample.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("DeletionUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierApiSample.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("LastModificationUser")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("AmplifierApiSample.Domain.Models.User", b =>
                {
                    b.HasOne("AmplifierApiSample.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("CreationUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierApiSample.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("DeletionUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierApiSample.Domain.Models.User")
                        .WithMany()
                        .HasForeignKey("LastModificationUser")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AmplifierApiSample.Domain.Models.Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
