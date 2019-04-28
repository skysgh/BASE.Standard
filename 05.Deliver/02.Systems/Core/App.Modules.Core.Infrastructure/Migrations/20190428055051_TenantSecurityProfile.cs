using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class TenantSecurityProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrincipalProfileTagAssignment");

            migrationBuilder.DropTable(
                name: "PrincipalProfileClaims",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalProfileProperties",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenancySecurityProfilePermissions",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalProfileTags",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalProfiles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalProfileCategories",
                schema: "Core");

            migrationBuilder.CreateTable(
                name: "TenantMemberProfileCategories",
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
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(nullable: false),
                    DisplayStyleHint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfileCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberProfileTags",
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
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(nullable: false),
                    DisplayStyleHint = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfileTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfilePermissions",
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
                    table.PrimaryKey("PK_TenantSecurityProfilePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfileRoleGroups",
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
                    Description = table.Column<string>(maxLength: 32768, nullable: true),
                    ParentFK = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfileRoleGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfileRoleGroups_TenantSecurityProfileRoleGroups_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfileRoles",
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
                    table.PrimaryKey("PK_TenantSecurityProfileRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberProfiles",
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
                    EnabledBeginningUtc = table.Column<DateTime>(nullable: true),
                    EnabledEndingUtc = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    DataClassificationFK = table.Column<int>(nullable: true),
                    CategoryFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantMemberProfiles_TenantMemberProfileCategories_CategoryFK",
                        column: x => x.CategoryFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfileCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantMemberProfiles_DataClassifications_DataClassificationFK",
                        column: x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfileRole2PermissionAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    RoleFK = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_TenantSecurityProfileRole2PermissionAssignments", x => new { x.TenantFK, x.RoleFK, x.PermissionFK });
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfileRole2PermissionAssignments_TenantSecurityProfilePermissions_PermissionFK",
                        column: x => x.PermissionFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfilePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfileRole2PermissionAssignments_TenantSecurityProfileRoles_RoleFK",
                        column: x => x.RoleFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfileRoleGroup2RoleAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    GroupFK = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_TenantSecurityProfileRoleGroup2RoleAssignments", x => new { x.TenantFK, x.GroupFK, x.RoleFK });
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfileRoleGroup2RoleAssignments_TenantSecurityProfileRoleGroups_GroupFK",
                        column: x => x.GroupFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantSecurityProfileRoleGroup2RoleAssignments_TenantSecurityProfileRoles_RoleFK",
                        column: x => x.RoleFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberProfile2TagAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    TenantPrincipalFK = table.Column<Guid>(nullable: false),
                    TagFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: true),
                    CreatedByPrincipalId = table.Column<string>(nullable: true),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: true),
                    LastModifiedByPrincipalId = table.Column<string>(nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfile2TagAssignments", x => new { x.TenantFK, x.TenantPrincipalFK, x.TagFK });
                    table.ForeignKey(
                        name: "FK_TenantMemberProfile2TagAssignments_TenantMemberProfileTags_TagFK",
                        column: x => x.TagFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfileTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenantMemberProfile2TagAssignments_TenantMemberProfiles_TenantPrincipalFK",
                        column: x => x.TenantPrincipalFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberProfileClaims",
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
                    Authority = table.Column<string>(maxLength: 64, nullable: false),
                    AuthoritySignature = table.Column<string>(maxLength: 32768, nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    PrincipalProfileFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfileClaims", x => x.Id);
                    table.UniqueConstraint("IX_TenantMemberProfileClaim_CompositeIndex", x => new { x.PrincipalProfileFK, x.Key });
                    table.ForeignKey(
                        name: "FK_TenantMemberProfileClaims_TenantMemberProfiles_PrincipalProfileFK",
                        column: x => x.PrincipalProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberProfileProperties",
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
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    PrincipalProfileFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfileProperties", x => x.Id);
                    table.UniqueConstraint("IX_TenantMemberProfileProperty_CompositeIndex", x => new { x.PrincipalProfileFK, x.Key });
                    table.ForeignKey(
                        name: "FK_TenantMemberProfileProperties_TenantMemberProfiles_PrincipalProfileFK",
                        column: x => x.PrincipalProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfile2TagAssignments_TagFK",
                schema: "Core",
                table: "TenantMemberProfile2TagAssignments",
                column: "TagFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfile2TagAssignments_TenantPrincipalFK",
                schema: "Core",
                table: "TenantMemberProfile2TagAssignments",
                column: "TenantPrincipalFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileCategory_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantMemberProfileCategories",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileCategory_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantMemberProfileCategories",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileCategory_RecordState",
                schema: "Core",
                table: "TenantMemberProfileCategories",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileCategory_TenantFK",
                schema: "Core",
                table: "TenantMemberProfileCategories",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileClaim_Authority",
                schema: "Core",
                table: "TenantMemberProfileClaims",
                column: "Authority");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileClaim_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantMemberProfileClaims",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileClaim_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantMemberProfileClaims",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileClaim_RecordState",
                schema: "Core",
                table: "TenantMemberProfileClaims",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileProperty_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantMemberProfileProperties",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileProperty_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantMemberProfileProperties",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileProperty_RecordState",
                schema: "Core",
                table: "TenantMemberProfileProperties",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileProperty_TenantFK",
                schema: "Core",
                table: "TenantMemberProfileProperties",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfiles_CategoryFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfiles_DataClassificationFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfile_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfile_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfile_RecordState",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfile_TenantFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileTag_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantMemberProfileTags",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileTag_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantMemberProfileTags",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileTag_RecordState",
                schema: "Core",
                table: "TenantMemberProfileTags",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfileTag_Title",
                schema: "Core",
                table: "TenantMemberProfileTags",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfilePermission_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfilePermission_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfilePermission_RecordState",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfilePermission_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfilePermission_Title",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2PermissionAssignment_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2PermissionAssignment_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2PermissionAssignments_PermissionFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "PermissionFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2PermissionAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2PermissionAssignments_RoleFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "RoleFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole2PermissionAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup2RoleAssignments_GroupFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "GroupFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup2RoleAssignment_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup2RoleAssignment_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup2RoleAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup2RoleAssignments_RoleFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "RoleFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup2RoleAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroups_ParentId",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup_Title",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRole_Title",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantMemberProfile2TagAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberProfileClaims",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberProfileProperties",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRole2PermissionAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRoleGroup2RoleAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberProfileTags",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberProfiles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfilePermissions",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRoleGroups",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRoles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberProfileCategories",
                schema: "Core");

            migrationBuilder.CreateTable(
                name: "PrincipalProfileCategories",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(nullable: false),
                    DisplayStyleHint = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalProfileCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalProfileTags",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(nullable: false),
                    DisplayStyleHint = table.Column<string>(maxLength: 64, nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Title = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalProfileTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenancySecurityProfilePermissions",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 32768, nullable: true),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Title = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenancySecurityProfilePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalProfiles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryFK = table.Column<Guid>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    DataClassificationFK = table.Column<int>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    EnabledBeginningUtc = table.Column<DateTime>(nullable: true),
                    EnabledEndingUtc = table.Column<DateTime>(nullable: true),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrincipalProfiles_PrincipalProfileCategories_CategoryFK",
                        column: x => x.CategoryFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalProfileCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrincipalProfiles_DataClassifications_DataClassificationFK",
                        column: x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalProfileTagAssignment",
                columns: table => new
                {
                    TenantPrincipalFK = table.Column<Guid>(nullable: false),
                    TagFK = table.Column<Guid>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    LastModifiedByPrincipalId = table.Column<string>(nullable: true),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalProfileTagAssignment", x => new { x.TenantPrincipalFK, x.TagFK });
                    table.ForeignKey(
                        name: "FK_PrincipalProfileTagAssignment_PrincipalProfileTags_TagFK",
                        column: x => x.TagFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalProfileTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrincipalProfileTagAssignment_PrincipalProfiles_TenantPrincipalFK",
                        column: x => x.TenantPrincipalFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalProfileClaims",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Authority = table.Column<string>(maxLength: 64, nullable: false),
                    AuthoritySignature = table.Column<string>(maxLength: 32768, nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    PrincipalProfileFK = table.Column<Guid>(nullable: false),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Value = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalProfileClaims", x => x.Id);
                    table.UniqueConstraint("IX_PrincipalProfileClaim_CompositeIndex", x => new { x.PrincipalProfileFK, x.Key });
                    table.ForeignKey(
                        name: "FK_PrincipalProfileClaims_PrincipalProfiles_PrincipalProfileFK",
                        column: x => x.PrincipalProfileFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalProfileProperties",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    PrincipalProfileFK = table.Column<Guid>(nullable: false),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Value = table.Column<string>(maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalProfileProperties", x => x.Id);
                    table.UniqueConstraint("IX_PrincipalProfileProperty_CompositeIndex", x => new { x.PrincipalProfileFK, x.Key });
                    table.ForeignKey(
                        name: "FK_PrincipalProfileProperties_PrincipalProfiles_PrincipalProfileFK",
                        column: x => x.PrincipalProfileFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileTagAssignment_TagFK",
                table: "PrincipalProfileTagAssignment",
                column: "TagFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileCategory_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalProfileCategories",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileCategory_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalProfileCategories",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileCategory_RecordState",
                schema: "Core",
                table: "PrincipalProfileCategories",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileCategory_TenantFK",
                schema: "Core",
                table: "PrincipalProfileCategories",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileClaim_Authority",
                schema: "Core",
                table: "PrincipalProfileClaims",
                column: "Authority");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileClaim_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalProfileClaims",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileClaim_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalProfileClaims",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileClaim_RecordState",
                schema: "Core",
                table: "PrincipalProfileClaims",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileProperty_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalProfileProperties",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileProperty_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalProfileProperties",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileProperty_RecordState",
                schema: "Core",
                table: "PrincipalProfileProperties",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileProperty_TenantFK",
                schema: "Core",
                table: "PrincipalProfileProperties",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfiles_CategoryFK",
                schema: "Core",
                table: "PrincipalProfiles",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfiles_DataClassificationFK",
                schema: "Core",
                table: "PrincipalProfiles",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfile_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalProfiles",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfile_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalProfiles",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfile_RecordState",
                schema: "Core",
                table: "PrincipalProfiles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfile_TenantFK",
                schema: "Core",
                table: "PrincipalProfiles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileTag_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalProfileTags",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileTag_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalProfileTags",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileTag_RecordState",
                schema: "Core",
                table: "PrincipalProfileTags",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProfileTag_Title",
                schema: "Core",
                table: "PrincipalProfileTags",
                column: "Title");

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
    }
}
