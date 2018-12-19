using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmplifierApiSample.Data.Migrations
{
    public partial class RemoveNameFromUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);          
        }
    }
}
