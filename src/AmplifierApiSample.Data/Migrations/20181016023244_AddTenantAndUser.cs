using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmplifierApiSample.Data.Migrations
{
    public partial class AddTenantAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<int>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: false),
                    DeletionUser = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: false),
                    LastModificationUser = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreationUser",
                        column: x => x.CreationUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletionUser",
                        column: x => x.DeletionUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_LastModificationUser",
                        column: x => x.LastModificationUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreationUser = table.Column<int>(nullable: false),
                    DeletionTime = table.Column<DateTime>(nullable: false),
                    DeletionUser = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastModificationTime = table.Column<DateTime>(nullable: false),
                    LastModificationUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_Users_CreationUser",
                        column: x => x.CreationUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tenants_Users_DeletionUser",
                        column: x => x.DeletionUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tenants_Users_LastModificationUser",
                        column: x => x.LastModificationUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_CreationUser",
                table: "Tenants",
                column: "CreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_DeletionUser",
                table: "Tenants",
                column: "DeletionUser");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_LastModificationUser",
                table: "Tenants",
                column: "LastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreationUser",
                table: "Users",
                column: "CreationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletionUser",
                table: "Users",
                column: "DeletionUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LastModificationUser",
                table: "Users",
                column: "LastModificationUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Tenants_TenantId",
                table: "Users",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Users_CreationUser",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Users_DeletionUser",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Users_LastModificationUser",
                table: "Tenants");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
