using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmplifierApiSample.Data.Migrations
{
    public partial class AddEmailIntoTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tenants",
                nullable: true);           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tenants");            
        }
    }
}
