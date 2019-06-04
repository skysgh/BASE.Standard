using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations.Steps
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.CreateTable(
                name: "DataClassifications",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 32768, nullable: true),
                    DisplayOrderHint = table.Column<int>(nullable: false),
                    DisplayStyleHint = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataClassifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DataTokens",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(maxLength: 32768, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionRecords",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateTimeCreatedUtc = table.Column<DateTime>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    ThreadId = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(maxLength: 32768, nullable: false),
                    Stack = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    PrincipalFK = table.Column<Guid>(nullable: false),
                    DateTimeCreatedUtc = table.Column<DateTime>(nullable: false),
                    DateTimeReadUtc = table.Column<DateTimeOffset>(nullable: true),
                    From = table.Column<string>(maxLength: 64, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 64, nullable: false),
                    Class = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalCategories",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(nullable: false),
                    DisplayStyleHint = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalTags",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(nullable: false),
                    DisplayStyleHint = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberProfileCategories",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
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
                    TenantFK = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 32768, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfilePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfileResponsibilities",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
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
                name: "TenantSecurityProfileRoleGroups",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
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
                    TenantFK = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(maxLength: 32768, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfileRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantSecurityProfiles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
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
                name: "MediaMetadatas",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    DataClassificationFK = table.Column<int>(nullable: false),
                    UploadedDateTimeUtc = table.Column<DateTime>(nullable: false),
                    ContentSize = table.Column<long>(nullable: false),
                    MimeType = table.Column<string>(maxLength: 256, nullable: false),
                    SourceFileName = table.Column<string>(maxLength: 256, nullable: false),
                    ContentHash = table.Column<string>(maxLength: 256, nullable: false),
                    LocalName = table.Column<string>(maxLength: 256, nullable: false),
                    LatestScanDateTimeUtc = table.Column<DateTimeOffset>(nullable: true),
                    LatestScanMalwareDetetected = table.Column<bool>(nullable: true),
                    LatestScanResults = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaMetadatas", x => x.Id);
                    table.UniqueConstraint("IX_MediaMetadata_LocalName", x => x.LocalName);
                    table.ForeignKey(
                        name: "FK_MediaMetadatas_DataClassifications_DataClassificationFK",
                        column: x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    IsDefault = table.Column<bool>(nullable: true),
                    HostName = table.Column<string>(maxLength: 64, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    DataClassificationFK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenants_DataClassifications_DataClassificationFK",
                        column: x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Principals",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    EnabledBeginningUtc = table.Column<DateTimeOffset>(nullable: true),
                    EnabledEndingUtc = table.Column<DateTimeOffset>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
                    DataClassificationFK = table.Column<int>(nullable: true),
                    CategoryFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Principals_PrincipalCategories_CategoryFK",
                        column: x => x.CategoryFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Principals_DataClassifications_DataClassificationFK",
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
                name: "TenantSecurityProfileRole2ResponsibilityAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(nullable: false),
                    RoleFK = table.Column<Guid>(nullable: false),
                    ResponsibilityFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
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
                name: "TenantMemberProfiles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    EnabledBeginningUtc = table.Column<DateTime>(nullable: true),
                    EnabledEndingUtc = table.Column<DateTime>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    DataClassificationFK = table.Column<int>(nullable: true),
                    CategoryFK = table.Column<Guid>(nullable: false),
                    SecurityProfileFK = table.Column<Guid>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_TenantMemberProfiles_TenantSecurityProfiles_SecurityProfileFK",
                        column: x => x.SecurityProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantMemberSecurityProfiles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
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
                name: "TenantClaims",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Authority = table.Column<string>(maxLength: 64, nullable: false),
                    AuthoritySignature = table.Column<string>(maxLength: 1024, nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    TenantFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantClaims_Tenants_TenantFK",
                        column: x => x.TenantFK,
                        principalSchema: "Core",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenantProperties",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    TenantFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenantProperties_Tenants_TenantFK",
                        column: x => x.TenantFK,
                        principalSchema: "Core",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalClaims",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Authority = table.Column<string>(maxLength: 64, nullable: false),
                    AuthoritySignature = table.Column<string>(maxLength: 32768, nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    PrincipalFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrincipalClaims_Principals_PrincipalFK",
                        column: x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalLogins",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    PrincipalFK = table.Column<Guid>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    IdPLogin = table.Column<string>(maxLength: 1024, nullable: false),
                    SubLogin = table.Column<string>(maxLength: 256, nullable: false),
                    LastLoggedInUtc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalLogins", x => x.Id);
                    table.UniqueConstraint("IX_PrincipalLogin_IdpLoginSubLogin", x => new { x.IdPLogin, x.SubLogin });
                    table.ForeignKey(
                        name: "FK_PrincipalLogins_Principals_PrincipalFK",
                        column: x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalProperties",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    PrincipalFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrincipalProperties_Principals_PrincipalFK",
                        column: x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalTagAssignments",
                schema: "Core",
                columns: table => new
                {
                    PrincipalFK = table.Column<Guid>(nullable: false),
                    TagFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    RecordState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalTagAssignments", x => new { x.PrincipalFK, x.TagFK });
                    table.ForeignKey(
                        name: "FK_PrincipalTagAssignments_Principals_PrincipalFK",
                        column: x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrincipalTagAssignments_PrincipalTags_TagFK",
                        column: x => x.TagFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    UniqueIdentifier = table.Column<string>(maxLength: 64, nullable: false),
                    DateTimeCreatedUtc = table.Column<DateTime>(nullable: false),
                    PrincipalFK = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.UniqueConstraint("IX_Session_UniqueIdentifier", x => x.UniqueIdentifier);
                    table.ForeignKey(
                        name: "FK_Sessions_Principals_PrincipalFK",
                        column: x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemRoles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    ModuleKey = table.Column<string>(nullable: true),
                    Key = table.Column<string>(maxLength: 64, nullable: false),
                    DataClassificationFK = table.Column<int>(nullable: true),
                    PrincipalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemRoles_DataClassifications_DataClassificationFK",
                        column: x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemRoles_Principals_PrincipalId",
                        column: x => x.PrincipalId,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    RecordState = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "SessionOperations",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    SessionFK = table.Column<Guid>(nullable: true),
                    ClientIp = table.Column<string>(maxLength: 64, nullable: false),
                    Url = table.Column<string>(maxLength: 32768, nullable: false),
                    ResourceTenantKey = table.Column<string>(nullable: true),
                    ControllerName = table.Column<string>(maxLength: 64, nullable: false),
                    ActionName = table.Column<string>(maxLength: 64, nullable: false),
                    ActionArguments = table.Column<string>(nullable: false),
                    BeginDateTimeUtc = table.Column<DateTimeOffset>(nullable: false),
                    EndDateTimeUtc = table.Column<DateTimeOffset>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    ResponseCode = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionOperations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionOperations_Sessions_SessionFK",
                        column: x => x.SessionFK,
                        principalSchema: "Core",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { 1, null, 1, null, false, 0, "Unspecified" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { 2, null, 2, null, false, 0, "Unclassified" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { 3, null, 3, null, false, 0, "In Confidence" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { 4, null, 4, null, false, 0, "Sensitive" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { 5, null, 5, null, false, 0, "Restricted" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { 6, null, 6, null, false, 0, "Confidential" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { 7, null, 7, null, false, 0, "Secret" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { 8, null, 8, null, false, 0, "TopSecret" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "ExceptionRecords",
                columns: new[] { "Id", "ClientId", "DateTimeCreatedUtc", "Level", "Message", "Stack", "ThreadId" },
                values: new object[] { new Guid("00000001-0000-0000-0000-000000000000"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Installation of System occurred on: 6/3/2019 5:58:46 AM +00:00", "", null });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "An error state as Principal type is not defined.", 0, null, true, 0, "Unspecified" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { new Guid("00000001-0000-0000-0000-000000000000"), "An error state as Principal type is unclear.", 0, null, true, 0, "Unknown" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { new Guid("00000002-0000-0000-0000-000000000000"), "This system.", 0, null, true, 0, "System" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { new Guid("00000003-0000-0000-0000-000000000000"), "A remote service or user.", 0, null, true, 0, "Default" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { new Guid("00000004-0000-0000-0000-000000000000"), "A remote service (whether owned by organisation or other.", 0, null, true, 0, "Service" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[] { "Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title" },
                values: new object[] { new Guid("00000005-0000-0000-0000-000000000000"), "General users.", 0, null, true, 0, "User" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Tenants",
                columns: new[] { "Id", "DataClassificationFK", "DisplayName", "Enabled", "HostName", "IsDefault", "Key", "RecordState" },
                values: new object[] { new Guid("00000001-0000-0000-0000-000000000000"), null, "Default", true, "Default", true, "Default", 0 });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Principals",
                columns: new[] { "Id", "CategoryFK", "DataClassificationFK", "DisplayName", "Enabled", "EnabledBeginningUtc", "EnabledEndingUtc", "FullName", "RecordState" },
                values: new object[] { new Guid("00000001-0000-0000-0000-000000000000"), new Guid("00000002-0000-0000-0000-000000000000"), null, "Anon", true, null, null, null, 0 });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Principals",
                columns: new[] { "Id", "CategoryFK", "DataClassificationFK", "DisplayName", "Enabled", "EnabledBeginningUtc", "EnabledEndingUtc", "FullName", "RecordState" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000003-0000-0000-0000-000000000000"), null, "Anon", true, null, null, null, 0 });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalProperties",
                columns: new[] { "Id", "Key", "PrincipalFK", "RecordState", "Value" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000000"), "Description", new Guid("00000000-0000-0000-0000-000000000000"), 0, "Principal shared by all unauthenticated users, but with distinct Sessions." });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalProperties",
                columns: new[] { "Id", "Key", "PrincipalFK", "RecordState", "Value" },
                values: new object[] { new Guid("00000001-0000-0000-0000-000000000000"), "FavoriteSong", new Guid("00000000-0000-0000-0000-000000000000"), 0, "https://www.youtube.com/watch?v=B1BdQcJ2ZYY" });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalProperties",
                columns: new[] { "Id", "Key", "PrincipalFK", "RecordState", "Value" },
                values: new object[] { new Guid("00000002-0000-0000-0000-000000000000"), "Seeking", new Guid("00000000-0000-0000-0000-000000000000"), 0, "Romance (what?! You think computers can't dream?!)." });

            migrationBuilder.CreateIndex(
                name: "IX_DataClassification_RecordState",
                schema: "Core",
                table: "DataClassifications",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_DataClassification_Title",
                schema: "Core",
                table: "DataClassifications",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_DataToken_RecordState",
                schema: "Core",
                table: "DataTokens",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_DataToken_TenantFK",
                schema: "Core",
                table: "DataTokens",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_MediaMetadata_ContentHash",
                schema: "Core",
                table: "MediaMetadatas",
                column: "ContentHash");

            migrationBuilder.CreateIndex(
                name: "IX_MediaMetadatas_DataClassificationFK",
                schema: "Core",
                table: "MediaMetadatas",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                name: "IX_MediaMetadata_RecordState",
                schema: "Core",
                table: "MediaMetadatas",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_MediaMetadata_SourceFileName",
                schema: "Core",
                table: "MediaMetadatas",
                column: "SourceFileName");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_From",
                schema: "Core",
                table: "Notifications",
                column: "From");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_PrincipalFK",
                schema: "Core",
                table: "Notifications",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_RecordState",
                schema: "Core",
                table: "Notifications",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalCategory_RecordState",
                schema: "Core",
                table: "PrincipalCategories",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalClaim_Authority",
                schema: "Core",
                table: "PrincipalClaims",
                column: "Authority");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalClaim_Key",
                schema: "Core",
                table: "PrincipalClaims",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalClaims_PrincipalFK",
                schema: "Core",
                table: "PrincipalClaims",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalClaim_RecordState",
                schema: "Core",
                table: "PrincipalClaims",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalLogins_PrincipalFK",
                schema: "Core",
                table: "PrincipalLogins",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalLogin_RecordState",
                schema: "Core",
                table: "PrincipalLogins",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProperty_Key",
                schema: "Core",
                table: "PrincipalProperties",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProperties_PrincipalFK",
                schema: "Core",
                table: "PrincipalProperties",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProperty_RecordState",
                schema: "Core",
                table: "PrincipalProperties",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_CategoryFK",
                schema: "Core",
                table: "Principals",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                name: "IX_Principals_DataClassificationFK",
                schema: "Core",
                table: "Principals",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                name: "IX_Principal_RecordState",
                schema: "Core",
                table: "Principals",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalTagAssignments_TagFK",
                schema: "Core",
                table: "PrincipalTagAssignments",
                column: "TagFK");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalTag_RecordState",
                schema: "Core",
                table: "PrincipalTags",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalTag_Title",
                schema: "Core",
                table: "PrincipalTags",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_SessionOperation_ActionName",
                schema: "Core",
                table: "SessionOperations",
                column: "ActionName");

            migrationBuilder.CreateIndex(
                name: "IX_SessionOperation_ControllerName",
                schema: "Core",
                table: "SessionOperations",
                column: "ControllerName");

            migrationBuilder.CreateIndex(
                name: "IX_SessionOperation_RecordState",
                schema: "Core",
                table: "SessionOperations",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_SessionOperations_SessionFK",
                schema: "Core",
                table: "SessionOperations",
                column: "SessionFK");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_PrincipalFK",
                schema: "Core",
                table: "Sessions",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                name: "IX_Session_RecordState",
                schema: "Core",
                table: "Sessions",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_DataClassificationFK",
                schema: "Core",
                table: "SystemRoles",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRole_Key",
                schema: "Core",
                table: "SystemRoles",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRoles_PrincipalId",
                schema: "Core",
                table: "SystemRoles",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRole_RecordState",
                schema: "Core",
                table: "SystemRoles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantClaim_Authority",
                schema: "Core",
                table: "TenantClaims",
                column: "Authority");

            migrationBuilder.CreateIndex(
                name: "IX_TenantClaim_Key",
                schema: "Core",
                table: "TenantClaims",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_TenantClaim_RecordState",
                schema: "Core",
                table: "TenantClaims",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantClaims_TenantFK",
                schema: "Core",
                table: "TenantClaims",
                column: "TenantFK");

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
                name: "IX_TenantMemberProfileClaim_RecordState",
                schema: "Core",
                table: "TenantMemberProfileClaims",
                column: "RecordState");

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
                name: "IX_TenantMemberProfile_RecordState",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfiles_SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "SecurityProfileFK");

            migrationBuilder.CreateIndex(
                name: "IX_TenantMemberProfile_TenantFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "TenantFK");

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
                name: "IX_TenantProperty_Key",
                schema: "Core",
                table: "TenantProperties",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_TenantProperty_RecordState",
                schema: "Core",
                table: "TenantProperties",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantProperties_TenantFK",
                schema: "Core",
                table: "TenantProperties",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_DataClassificationFK",
                schema: "Core",
                table: "Tenants",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_DisplayName",
                schema: "Core",
                table: "Tenants",
                column: "DisplayName");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_Key",
                schema: "Core",
                table: "Tenants",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_RecordState",
                schema: "Core",
                table: "Tenants",
                column: "RecordState");

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

            migrationBuilder.CreateIndex(
                name: "IX_TenantSecurityProfileRoleGroup2RoleAssignments_GroupFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "GroupFK");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataTokens",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "ExceptionRecords",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "MediaMetadatas",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Notifications",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalClaims",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalLogins",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalProperties",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalTagAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "SessionOperations",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "SystemRoles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantClaims",
                schema: "Core");

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
                name: "TenantMemberSecurityProfile2PermissionAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantProperties",
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
                name: "TenantSecurityProfileRole2PermissionAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRole2ResponsibilityAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRoleGroup2RoleAssignments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalTags",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberProfileTags",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberProfiles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberSecurityProfiles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfilePermissions",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileResponsibilities",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRoleGroups",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfileRoles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Principals",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantMemberProfileCategories",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantSecurityProfiles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalCategories",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "DataClassifications",
                schema: "Core");
        }
    }
}
