using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmplifierApiSample.Data.Migrations
{
    public partial class UpdateAuditProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastModificationUser",
                table: "Tenants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DeletionUser",
                table: "Tenants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CreationUser",
                table: "Tenants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LastModificationUser",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DeletionUser",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CreationUser",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4c157928-7c57-41e3-a58f-ca7514546a6e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreationTime", "DeletionTime", "LastModificationTime", "PasswordHash" },
                values: new object[] { "32fe9448-0c6c-43b2-b605-802c19c333a6", new DateTime(2018, 12, 10, 21, 31, 39, 94, DateTimeKind.Local), new DateTime(2018, 12, 10, 21, 31, 39, 97, DateTimeKind.Local), new DateTime(2018, 12, 10, 21, 31, 39, 97, DateTimeKind.Local), "AQAAAAEAACcQAAAAEIyYVzBXCyHLBa/p7Ve+9XzLldAqaIJ4N+0j36VFu5x/3/WlDU99TMwxIiwEh/Ar9g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastModificationUser",
                table: "Tenants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeletionUser",
                table: "Tenants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreationUser",
                table: "Tenants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastModificationUser",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeletionUser",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreationUser",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "81d351d9-2e85-401b-8320-8ecfe098f1e1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreationTime", "DeletionTime", "LastModificationTime", "PasswordHash" },
                values: new object[] { "32fe9448-0c6c-43b2-b605-802c19c333a6", new DateTime(2018, 12, 9, 13, 20, 29, 359, DateTimeKind.Local), new DateTime(2018, 12, 9, 13, 20, 29, 362, DateTimeKind.Local), new DateTime(2018, 12, 9, 13, 20, 29, 362, DateTimeKind.Local), "AQAAAAEAACcQAAAAEIxDDsk4qtIBOe9dZFSl7r0tv5bGjZ3JSXj7xjMS68N8u2JORPzQk3SZSy9O14xjoQ==" });
        }
    }
}
