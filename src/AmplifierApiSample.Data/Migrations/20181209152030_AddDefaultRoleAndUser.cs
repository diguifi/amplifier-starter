using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmplifierApiSample.Data.Migrations
{
    public partial class AddDefaultRoleAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { 1, "81d351d9-2e85-401b-8320-8ecfe098f1e1", "Role", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreationTime", "CreationUser", "DeletionTime", "DeletionUser", "Email", "EmailConfirmed", "IsDeleted", "LastModificationTime", "LastModificationUser", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "32fe9448-0c6c-43b2-b605-802c19c333a6", new DateTime(2018, 12, 9, 13, 20, 29, 359, DateTimeKind.Local), 1, new DateTime(2018, 12, 9, 13, 20, 29, 362, DateTimeKind.Local), 1, "admin@admin.com", true, false, new DateTime(2018, 12, 9, 13, 20, 29, 362, DateTimeKind.Local), 1, false, null, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEIxDDsk4qtIBOe9dZFSl7r0tv5bGjZ3JSXj7xjMS68N8u2JORPzQk3SZSy9O14xjoQ==", "123", true, "ce907fd5-ccb4-4e96-a7ea-45712a14f5ef", null, false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 1, "81d351d9-2e85-401b-8320-8ecfe098f1e1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 1, "32fe9448-0c6c-43b2-b605-802c19c333a6" });

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }
    }
}
