using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class Permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenancySecurityProfilePermissions",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 32768, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenancySecurityProfilePermissions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenancySecurityProfilePermission_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenancySecurityProfilePermissions",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenancySecurityProfilePermission_LastModifiedOnUtc",
                schema: "Core",
                table: "TenancySecurityProfilePermissions",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenancySecurityProfilePermission_RecordState",
                schema: "Core",
                table: "TenancySecurityProfilePermissions",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenancySecurityProfilePermission_TenantFK",
                schema: "Core",
                table: "TenancySecurityProfilePermissions",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenancySecurityProfilePermission_Title",
                schema: "Core",
                table: "TenancySecurityProfilePermissions",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenancySecurityProfilePermissions",
                schema: "Core");
        }
    }
}
