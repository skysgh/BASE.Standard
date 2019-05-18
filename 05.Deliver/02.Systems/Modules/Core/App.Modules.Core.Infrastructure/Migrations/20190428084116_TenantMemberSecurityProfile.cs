using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class TenantMemberSecurityProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfiles",
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
                    table.PrimaryKey("PK_TenantSecurityProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberSecurityProfiles",
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
                    SecurityProfileFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberSecurityProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantMemberSecurityProfiles_TenantSecurityProfiles_SecurityProfileFK",
                        column: x => x.SecurityProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfile2PermissionAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    ProfileFK = table.Column<Guid>(nullable: false),
                    PermissionFK = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_TenantSecurityProfile2PermissionAssignments", x => new { x.TenantFK, x.ProfileFK, x.PermissionFK });
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfile2PermissionAssignments_TenantSecurityProfilePermissions_PermissionFK",
                        column: x => x.PermissionFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfilePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfile2PermissionAssignments_TenantSecurityProfiles_ProfileFK",
                        column: x => x.ProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfile2RoleAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    ProfileFK = table.Column<Guid>(nullable: false),
                    RoleFK = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_TenantSecurityProfile2RoleAssignments", x => new { x.TenantFK, x.ProfileFK, x.RoleFK });
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfile2RoleAssignments_TenantSecurityProfiles_ProfileFK",
                        column: x => x.ProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfile2RoleAssignments_TenantSecurityProfileRoles_RoleFK",
                        column: x => x.RoleFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfile2RoleGroupAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    ProfileFK = table.Column<Guid>(nullable: false),
                    RoleGroupFK = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_TenantSecurityProfile2RoleGroupAssignments", x => new { x.TenantFK, x.ProfileFK, x.RoleGroupFK });
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfile2RoleGroupAssignments_TenantSecurityProfiles_ProfileFK",
                        column: x => x.ProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfile2RoleGroupAssignments_TenantSecurityProfileRoleGroups_RoleGroupFK",
                        column: x => x.RoleGroupFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberSecurityProfile2PermissionAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    MemberFK = table.Column<Guid>(nullable: false),
                    PermissionFK = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_TenantMemberSecurityProfile2PermissionAssignments", x => new { x.TenantFK, x.MemberFK, x.PermissionFK });
                    table.ForeignKey(
                        name: "FK_TenantMemberSecurityProfile2PermissionAssignments_TenantMemberSecurityProfiles_MemberFK",
                        column: x => x.MemberFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantMemberSecurityProfile2PermissionAssignments_TenantSecurityProfilePermissions_PermissionFK",
                        column: x => x.PermissionFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfilePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfiles_SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "SecurityProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile2PermissionAssignment_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile2PermissionAssignment_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile2PermissionAssignments_MemberFK",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "MemberFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile2PermissionAssignments_PermissionFK",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "PermissionFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile2PermissionAssignment_RecordState",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile2PermissionAssignment_TenantFK",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantMemberSecurityProfiles",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantMemberSecurityProfiles",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile_RecordState",
                schema: "Core",
                table: "TenantMemberSecurityProfiles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfiles_SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberSecurityProfiles",
                column: "SecurityProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberSecurityProfile_TenantFK",
                schema: "Core",
                table: "TenantMemberSecurityProfiles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2PermissionAssignment_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2PermissionAssignment_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2PermissionAssignments_PermissionFK",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "PermissionFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2PermissionAssignments_ProfileFK",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "ProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2PermissionAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2PermissionAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleAssignment_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleAssignment_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleAssignments_ProfileFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "ProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleAssignments_RoleFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "RoleFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleGroupAssignment_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleGroupAssignment_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleGroupAssignments_ProfileFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "ProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleGroupAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleGroupAssignments_RoleGroupFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "RoleGroupFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile2RoleGroupAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfiles",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfiles",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile_RecordState",
                schema: "Core",
                table: "TenantSecurityProfiles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfiles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfile_Title",
                schema: "Core",
                table: "TenantSecurityProfiles",
                column: "Title");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantMemberProfiles_TenantSecurityProfiles_SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "SecurityProfileFK",
                principalSchema: "Core",
                principalTable: "TenantSecurityProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantMemberProfiles_TenantSecurityProfiles_SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberProfiles");

            migrationBuilder.DropTable(
                name: "TenantMemberSecurityProfile2PermissionAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfile2PermissionAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfile2RoleAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfile2RoleGroupAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberSecurityProfiles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfiles",
                schema: "Core");

            migrationBuilder.DropIndex(
                name: "IX_TenantMemberProfiles_SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberProfiles");

            migrationBuilder.DropColumn(
                name: "Enabled",
                schema: "Core",
                table: "TenantSecurityProfileRoles");

            migrationBuilder.DropColumn(
                name: "Enabled",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups");

            migrationBuilder.DropColumn(
                name: "Enabled",
                schema: "Core",
                table: "TenantSecurityProfilePermissions");

            migrationBuilder.DropColumn(
                name: "SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberProfiles");
        }
    }
}
