using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class Responsibility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenantSecurityProfileResponsibilities",
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
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 32768, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfileResponsibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfileRole2ResponsibilityAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    RoleFK = table.Column<Guid>(nullable: false),
                    ResponsibilityFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
                    AssignmentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfileRole2ResponsibilityAssignments", x => new { x.TenantFK, x.RoleFK, x.ResponsibilityFK });
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfileRole2ResponsibilityAssignments_TenantSecurityProfileResponsibilities_ResponsibilityFK",
                        column: x => x.ResponsibilityFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileResponsibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfileRole2ResponsibilityAssignments_TenantSecurityProfileRoles_RoleFK",
                        column: x => x.RoleFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileResponsibility_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfileResponsibilities",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileResponsibility_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfileResponsibilities",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileResponsibility_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileResponsibilities",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileResponsibility_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileResponsibilities",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileResponsibility_Title",
                schema: "Core",
                table: "TenantSecurityProfileResponsibilities",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2ResponsibilityAssignment_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2ResponsibilityAssignment_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2ResponsibilityAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2ResponsibilityAssignments_ResponsibilityFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "ResponsibilityFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2ResponsibilityAssignments_RoleFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "RoleFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2ResponsibilityAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "TenantFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRole2ResponsibilityAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileResponsibilities",
                schema: "Core");
        }
    }
}
