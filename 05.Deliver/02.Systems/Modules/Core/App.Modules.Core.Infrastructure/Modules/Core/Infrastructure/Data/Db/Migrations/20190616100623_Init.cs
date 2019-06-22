// Copyright MachineBrains, Inc. 2019

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Data.Db.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "Core");

            migrationBuilder.CreateTable(
                "DataClassifications",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(maxLength: 64),
                    Description = table.Column<string>(maxLength: 32768, nullable: true),
                    DisplayOrderHint = table.Column<int>(),
                    DisplayStyleHint = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_DataClassifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "DataTokens",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Value = table.Column<string>(maxLength: 32768)
                },
                constraints: table => { table.PrimaryKey("PK_DataTokens", x => x.Id); });

            migrationBuilder.CreateTable(
                "ExceptionRecords",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    UtcDateTimeCreated = table.Column<DateTimeOffset>(),
                    Level = table.Column<int>(),
                    ThreadId = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(maxLength: 32768),
                    Stack = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_ExceptionRecords", x => x.Id); });

            migrationBuilder.CreateTable(
                "Notifications",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Type = table.Column<int>(),
                    Level = table.Column<int>(),
                    PrincipalFK = table.Column<Guid>(),
                    DateTimeCreatedUtc = table.Column<DateTime>(),
                    DateTimeReadUtc = table.Column<DateTimeOffset>(nullable: true),
                    From = table.Column<string>(maxLength: 64),
                    ImageUrl = table.Column<string>(maxLength: 64),
                    Class = table.Column<string>(maxLength: 64),
                    Value = table.Column<int>(),
                    Text = table.Column<string>()
                },
                constraints: table => { table.PrimaryKey("PK_Notifications", x => x.Id); });

            migrationBuilder.CreateTable(
                "PrincipalCategories",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(),
                    DisplayStyleHint = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_PrincipalCategories", x => x.Id); });

            migrationBuilder.CreateTable(
                "PrincipalTags",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(maxLength: 64),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(),
                    DisplayStyleHint = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_PrincipalTags", x => x.Id); });

            migrationBuilder.CreateTable(
                "TenantMemberProfileCategories",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(),
                    DisplayStyleHint = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_TenantMemberProfileCategories", x => x.Id); });

            migrationBuilder.CreateTable(
                "TenantMemberProfileTags",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(maxLength: 64),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(),
                    DisplayStyleHint = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_TenantMemberProfileTags", x => x.Id); });

            migrationBuilder.CreateTable(
                "TenantSecurityProfilePermissions",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(maxLength: 64),
                    Description = table.Column<string>(maxLength: 32768, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_TenantSecurityProfilePermissions", x => x.Id); });

            migrationBuilder.CreateTable(
                "TenantSecurityProfileResponsibilities",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(maxLength: 64),
                    Description = table.Column<string>(maxLength: 32768, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_TenantSecurityProfileResponsibilities", x => x.Id); });

            migrationBuilder.CreateTable(
                "TenantSecurityProfileRoleGroups",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(maxLength: 64),
                    Description = table.Column<string>(maxLength: 32768, nullable: true),
                    ParentFK = table.Column<Guid>(nullable: true),
                    ParentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfileRoleGroups", x => x.Id);
                    table.ForeignKey(
                        "FK_TenantSecurityProfileRoleGroups_TenantSecurityProfileRoleGroups_ParentId",
                        x => x.ParentId,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "TenantSecurityProfileRoles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(maxLength: 64),
                    Description = table.Column<string>(maxLength: 32768, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_TenantSecurityProfileRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "TenantSecurityProfiles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    Title = table.Column<string>(maxLength: 64),
                    Description = table.Column<string>(maxLength: 32768, nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_TenantSecurityProfiles", x => x.Id); });

            migrationBuilder.CreateTable(
                "MediaMetadatas",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    DataClassificationFK = table.Column<int>(),
                    UploadedDateTimeUtc = table.Column<DateTime>(),
                    ContentSize = table.Column<long>(),
                    MimeType = table.Column<string>(maxLength: 256),
                    SourceFileName = table.Column<string>(maxLength: 256),
                    ContentHash = table.Column<string>(maxLength: 256),
                    LocalName = table.Column<string>(maxLength: 256),
                    LatestScanDateTimeUtc = table.Column<DateTimeOffset>(nullable: true),
                    LatestScanMalwareDetetected = table.Column<bool>(nullable: true),
                    LatestScanResults = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaMetadatas", x => x.Id);
                    table.UniqueConstraint("IX_MediaMetadata_LocalName", x => x.LocalName);
                    table.ForeignKey(
                        "FK_MediaMetadatas_DataClassifications_DataClassificationFK",
                        x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Tenants",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    Key = table.Column<string>(maxLength: 64),
                    IsDefault = table.Column<bool>(nullable: true),
                    HostName = table.Column<string>(maxLength: 64, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 64),
                    DataClassificationFK = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                    table.ForeignKey(
                        "FK_Tenants_DataClassifications_DataClassificationFK",
                        x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Principals",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    EnabledBeginningUtcDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EnabledEndingUtcDateTime = table.Column<DateTimeOffset>(nullable: true),
                    Enabled = table.Column<bool>(),
                    FullName = table.Column<string>(maxLength: 128, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: true),
                    DataClassificationFK = table.Column<int>(),
                    CategoryFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Principals", x => x.Id);
                    table.ForeignKey(
                        "FK_Principals_PrincipalCategories_CategoryFK",
                        x => x.CategoryFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Principals_DataClassifications_DataClassificationFK",
                        x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantSecurityProfileRole2PermissionAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(),
                    RoleFK = table.Column<Guid>(),
                    PermissionFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    AssignmentType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfileRole2PermissionAssignments",
                        x => new {x.TenantFK, x.RoleFK, x.PermissionFK});
                    table.ForeignKey(
                        "FK_TenantSecurityProfileRole2PermissionAssignments_TenantSecurityProfilePermissions_PermissionFK",
                        x => x.PermissionFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfilePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantSecurityProfileRole2PermissionAssignments_TenantSecurityProfileRoles_RoleFK",
                        x => x.RoleFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantSecurityProfileRole2ResponsibilityAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(),
                    RoleFK = table.Column<Guid>(),
                    ResponsibilityFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    AssignmentType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfileRole2ResponsibilityAssignments",
                        x => new {x.TenantFK, x.RoleFK, x.ResponsibilityFK});
                    table.ForeignKey(
                        "FK_TenantSecurityProfileRole2ResponsibilityAssignments_TenantSecurityProfileResponsibilities_ResponsibilityFK",
                        x => x.ResponsibilityFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileResponsibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantSecurityProfileRole2ResponsibilityAssignments_TenantSecurityProfileRoles_RoleFK",
                        x => x.RoleFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantSecurityProfileRoleGroup2RoleAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(),
                    GroupFK = table.Column<Guid>(),
                    RoleFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    AssignmentType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfileRoleGroup2RoleAssignments",
                        x => new {x.TenantFK, x.GroupFK, x.RoleFK});
                    table.ForeignKey(
                        "FK_TenantSecurityProfileRoleGroup2RoleAssignments_TenantSecurityProfileRoleGroups_GroupFK",
                        x => x.GroupFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantSecurityProfileRoleGroup2RoleAssignments_TenantSecurityProfileRoles_RoleFK",
                        x => x.RoleFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantMemberProfiles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    EnabledBeginningUtcDateTime = table.Column<DateTimeOffset>(nullable: true),
                    EnabledEndingUtcDateTime = table.Column<DateTimeOffset>(nullable: true),
                    Enabled = table.Column<bool>(),
                    DisplayName = table.Column<string>(nullable: true),
                    DataClassificationFK = table.Column<int>(nullable: true),
                    CategoryFK = table.Column<Guid>(),
                    SecurityProfileFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfiles", x => x.Id);
                    table.ForeignKey(
                        "FK_TenantMemberProfiles_TenantMemberProfileCategories_CategoryFK",
                        x => x.CategoryFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfileCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantMemberProfiles_DataClassifications_DataClassificationFK",
                        x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_TenantMemberProfiles_TenantSecurityProfiles_SecurityProfileFK",
                        x => x.SecurityProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantMemberSecurityProfiles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    SecurityProfileFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberSecurityProfiles", x => x.Id);
                    table.ForeignKey(
                        "FK_TenantMemberSecurityProfiles_TenantSecurityProfiles_SecurityProfileFK",
                        x => x.SecurityProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantSecurityProfile2PermissionAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(),
                    ProfileFK = table.Column<Guid>(),
                    PermissionFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    AssignmentType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfile2PermissionAssignments",
                        x => new {x.TenantFK, x.ProfileFK, x.PermissionFK});
                    table.ForeignKey(
                        "FK_TenantSecurityProfile2PermissionAssignments_TenantSecurityProfilePermissions_PermissionFK",
                        x => x.PermissionFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfilePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantSecurityProfile2PermissionAssignments_TenantSecurityProfiles_ProfileFK",
                        x => x.ProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantSecurityProfile2RoleAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(),
                    ProfileFK = table.Column<Guid>(),
                    RoleFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    AssignmentType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfile2RoleAssignments",
                        x => new {x.TenantFK, x.ProfileFK, x.RoleFK});
                    table.ForeignKey(
                        "FK_TenantSecurityProfile2RoleAssignments_TenantSecurityProfiles_ProfileFK",
                        x => x.ProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantSecurityProfile2RoleAssignments_TenantSecurityProfileRoles_RoleFK",
                        x => x.RoleFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantSecurityProfile2RoleGroupAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(),
                    ProfileFK = table.Column<Guid>(),
                    RoleGroupFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    AssignmentType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantSecurityProfile2RoleGroupAssignments",
                        x => new {x.TenantFK, x.ProfileFK, x.RoleGroupFK});
                    table.ForeignKey(
                        "FK_TenantSecurityProfile2RoleGroupAssignments_TenantSecurityProfiles_ProfileFK",
                        x => x.ProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantSecurityProfile2RoleGroupAssignments_TenantSecurityProfileRoleGroups_RoleGroupFK",
                        x => x.RoleGroupFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfileRoleGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantClaims",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Authority = table.Column<string>(maxLength: 64),
                    AuthoritySignature = table.Column<string>(maxLength: 1024),
                    Key = table.Column<string>(maxLength: 64),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    TenantFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_TenantClaims_Tenants_TenantFK",
                        x => x.TenantFK,
                        principalSchema: "Core",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantProperties",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Key = table.Column<string>(maxLength: 64),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    TenantFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_TenantProperties_Tenants_TenantFK",
                        x => x.TenantFK,
                        principalSchema: "Core",
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PrincipalClaims",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Authority = table.Column<string>(maxLength: 64),
                    AuthoritySignature = table.Column<string>(maxLength: 32768),
                    Key = table.Column<string>(maxLength: 64),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    PrincipalFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_PrincipalClaims_Principals_PrincipalFK",
                        x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PrincipalLogins",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    PrincipalFK = table.Column<Guid>(),
                    Enabled = table.Column<bool>(),
                    IdPLogin = table.Column<string>(maxLength: 1024),
                    SubLogin = table.Column<string>(maxLength: 256),
                    LastLoggedInUtc = table.Column<DateTime>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalLogins", x => x.Id);
                    table.UniqueConstraint("IX_PrincipalLogin_IdpLoginSubLogin", x => new {x.IdPLogin, x.SubLogin});
                    table.ForeignKey(
                        "FK_PrincipalLogins_Principals_PrincipalFK",
                        x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PrincipalProperties",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Key = table.Column<string>(maxLength: 64),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    PrincipalFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalProperties", x => x.Id);
                    table.ForeignKey(
                        "FK_PrincipalProperties_Principals_PrincipalFK",
                        x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PrincipalTagAssignments",
                schema: "Core",
                columns: table => new
                {
                    PrincipalFK = table.Column<Guid>(),
                    TagFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    RecordState = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalTagAssignments", x => new {x.PrincipalFK, x.TagFK});
                    table.ForeignKey(
                        "FK_PrincipalTagAssignments_Principals_PrincipalFK",
                        x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_PrincipalTagAssignments_PrincipalTags_TagFK",
                        x => x.TagFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Sessions",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    UniqueIdentifier = table.Column<string>(maxLength: 64),
                    UtcDateTimeCreated = table.Column<DateTimeOffset>(),
                    PrincipalFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.UniqueConstraint("IX_Session_UniqueIdentifier", x => x.UniqueIdentifier);
                    table.ForeignKey(
                        "FK_Sessions_Principals_PrincipalFK",
                        x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SystemRoles",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Enabled = table.Column<bool>(),
                    ModuleKey = table.Column<string>(nullable: true),
                    Key = table.Column<string>(maxLength: 64),
                    DataClassificationFK = table.Column<int>(),
                    PrincipalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemRoles", x => x.Id);
                    table.ForeignKey(
                        "FK_SystemRoles_DataClassifications_DataClassificationFK",
                        x => x.DataClassificationFK,
                        principalSchema: "Core",
                        principalTable: "DataClassifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_SystemRoles_Principals_PrincipalId",
                        x => x.PrincipalId,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "TenantMemberProfile2TagAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(),
                    TenantPrincipalFK = table.Column<Guid>(),
                    TagFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    RecordState = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfile2TagAssignments",
                        x => new {x.TenantFK, x.TenantPrincipalFK, x.TagFK});
                    table.ForeignKey(
                        "FK_TenantMemberProfile2TagAssignments_TenantMemberProfileTags_TagFK",
                        x => x.TagFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfileTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantMemberProfile2TagAssignments_TenantMemberProfiles_TenantPrincipalFK",
                        x => x.TenantPrincipalFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantMemberProfileClaims",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Authority = table.Column<string>(maxLength: 64),
                    AuthoritySignature = table.Column<string>(maxLength: 32768),
                    Key = table.Column<string>(maxLength: 64),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    PrincipalProfileFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfileClaims", x => x.Id);
                    table.UniqueConstraint("IX_TenantMemberProfileClaim_CompositeIndex",
                        x => new {x.PrincipalProfileFK, x.Key});
                    table.ForeignKey(
                        "FK_TenantMemberProfileClaims_TenantMemberProfiles_PrincipalProfileFK",
                        x => x.PrincipalProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantMemberProfileProperties",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Key = table.Column<string>(maxLength: 64),
                    Value = table.Column<string>(maxLength: 1024, nullable: true),
                    PrincipalProfileFK = table.Column<Guid>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberProfileProperties", x => x.Id);
                    table.UniqueConstraint("IX_TenantMemberProfileProperty_CompositeIndex",
                        x => new {x.PrincipalProfileFK, x.Key});
                    table.ForeignKey(
                        "FK_TenantMemberProfileProperties_TenantMemberProfiles_PrincipalProfileFK",
                        x => x.PrincipalProfileFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "TenantMemberSecurityProfile2PermissionAssignments",
                schema: "Core",
                columns: table => new
                {
                    TenantFK = table.Column<Guid>(),
                    MemberFK = table.Column<Guid>(),
                    PermissionFK = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    AssignmentType = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantMemberSecurityProfile2PermissionAssignments",
                        x => new {x.TenantFK, x.MemberFK, x.PermissionFK});
                    table.ForeignKey(
                        "FK_TenantMemberSecurityProfile2PermissionAssignments_TenantMemberSecurityProfiles_MemberFK",
                        x => x.MemberFK,
                        principalSchema: "Core",
                        principalTable: "TenantMemberSecurityProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_TenantMemberSecurityProfile2PermissionAssignments_TenantSecurityProfilePermissions_PermissionFK",
                        x => x.PermissionFK,
                        principalSchema: "Core",
                        principalTable: "TenantSecurityProfilePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SessionOperations",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    SessionFK = table.Column<Guid>(nullable: true),
                    ClientIp = table.Column<string>(maxLength: 64),
                    Url = table.Column<string>(maxLength: 32768),
                    ResourceTenantKey = table.Column<string>(nullable: true),
                    ControllerName = table.Column<string>(maxLength: 64),
                    ActionName = table.Column<string>(maxLength: 64),
                    ActionArguments = table.Column<string>(),
                    BeginDateTimeUtc = table.Column<DateTimeOffset>(),
                    EndDateTimeUtc = table.Column<DateTimeOffset>(),
                    Duration = table.Column<TimeSpan>(),
                    ResponseCode = table.Column<string>(maxLength: 64)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionOperations", x => x.Id);
                    table.ForeignKey(
                        "FK_SessionOperations_Sessions_SessionFK",
                        x => x.SessionFK,
                        principalSchema: "Core",
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[] {1, null, 1, null, false, 0, "Unspecified"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[] {2, null, 2, null, false, 0, "Unclassified"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[] {3, null, 3, null, false, 0, "In Confidence"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[] {4, null, 4, null, false, 0, "Sensitive"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[] {5, null, 5, null, false, 0, "Restricted"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[] {6, null, 6, null, false, 0, "Confidential"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[] {7, null, 7, null, false, 0, "Secret"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "DataClassifications",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[] {8, null, 8, null, false, 0, "TopSecret"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "ExceptionRecords",
                columns: new[] {"Id", "ClientId", "Level", "Message", "Stack", "ThreadId", "UtcDateTimeCreated"},
                values: new object[]
                {
                    new Guid("00000001-0000-0000-0000-000000000000"), null, 3,
                    "Installation of System occurred on: 6/16/2019 10:06:23 AM +00:00", "", null,
                    new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        new TimeSpan(0, 0, 0, 0, 0))
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[]
                {
                    new Guid("00000000-0000-0000-0000-000000000000"),
                    "An error state as Principal type is not defined.", 0, null, true, 0, "Unspecified"
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[]
                {
                    new Guid("00000001-0000-0000-0000-000000000000"), "An error state as Principal type is unclear.", 0,
                    null, true, 0, "Unknown"
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[]
                    {new Guid("00000002-0000-0000-0000-000000000000"), "This system.", 0, null, true, 0, "System"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[]
                {
                    new Guid("00000003-0000-0000-0000-000000000000"), "A remote service or user.", 0, null, true, 0,
                    "Default"
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[]
                {
                    new Guid("00000004-0000-0000-0000-000000000000"),
                    "A remote service (whether owned by organisation or other.", 0, null, true, 0, "Service"
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalCategories",
                columns: new[]
                    {"Id", "Description", "DisplayOrderHint", "DisplayStyleHint", "Enabled", "RecordState", "Title"},
                values: new object[]
                    {new Guid("00000005-0000-0000-0000-000000000000"), "General users.", 0, null, true, 0, "User"});

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Principals",
                columns: new[]
                {
                    "Id", "CategoryFK", "DataClassificationFK", "DisplayName", "Enabled", "EnabledBeginningUtcDateTime",
                    "EnabledEndingUtcDateTime", "FullName", "RecordState"
                },
                values: new object[]
                {
                    new Guid("00000001-0000-0000-0000-000000000000"), new Guid("00000002-0000-0000-0000-000000000000"),
                    2, "Anon", true, null, null, null, 0
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Principals",
                columns: new[]
                {
                    "Id", "CategoryFK", "DataClassificationFK", "DisplayName", "Enabled", "EnabledBeginningUtcDateTime",
                    "EnabledEndingUtcDateTime", "FullName", "RecordState"
                },
                values: new object[]
                {
                    new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000003-0000-0000-0000-000000000000"),
                    2, "Anon", true, null, null, null, 0
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "Tenants",
                columns: new[]
                {
                    "Id", "DataClassificationFK", "DisplayName", "Enabled", "HostName", "IsDefault", "Key",
                    "RecordState"
                },
                values: new object[]
                {
                    new Guid("00000001-0000-0000-0000-000000000000"), 2, "Default", true, "Default", true, "Default", 0
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalProperties",
                columns: new[] {"Id", "Key", "PrincipalFK", "RecordState", "Value"},
                values: new object[]
                {
                    new Guid("00000000-0000-0000-0000-000000000000"), "Description",
                    new Guid("00000000-0000-0000-0000-000000000000"), 0,
                    "Principal shared by all unauthenticated users, but with distinct Sessions."
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalProperties",
                columns: new[] {"Id", "Key", "PrincipalFK", "RecordState", "Value"},
                values: new object[]
                {
                    new Guid("00000001-0000-0000-0000-000000000000"), "FavoriteSong",
                    new Guid("00000000-0000-0000-0000-000000000000"), 0, "https://www.youtube.com/watch?v=B1BdQcJ2ZYY"
                });

            migrationBuilder.InsertData(
                schema: "Core",
                table: "PrincipalProperties",
                columns: new[] {"Id", "Key", "PrincipalFK", "RecordState", "Value"},
                values: new object[]
                {
                    new Guid("00000002-0000-0000-0000-000000000000"), "Seeking",
                    new Guid("00000000-0000-0000-0000-000000000000"), 0,
                    "Romance (what?! You think computers can't dream?!)."
                });

            migrationBuilder.CreateIndex(
                "IX_DataClassification_RecordState",
                schema: "Core",
                table: "DataClassifications",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_DataClassification_Title",
                schema: "Core",
                table: "DataClassifications",
                column: "Title");

            migrationBuilder.CreateIndex(
                "IX_DataToken_RecordState",
                schema: "Core",
                table: "DataTokens",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_DataToken_TenantFK",
                schema: "Core",
                table: "DataTokens",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_MediaMetadata_ContentHash",
                schema: "Core",
                table: "MediaMetadatas",
                column: "ContentHash");

            migrationBuilder.CreateIndex(
                "IX_MediaMetadatas_DataClassificationFK",
                schema: "Core",
                table: "MediaMetadatas",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                "IX_MediaMetadata_RecordState",
                schema: "Core",
                table: "MediaMetadatas",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_MediaMetadata_SourceFileName",
                schema: "Core",
                table: "MediaMetadatas",
                column: "SourceFileName");

            migrationBuilder.CreateIndex(
                "IX_Notification_From",
                schema: "Core",
                table: "Notifications",
                column: "From");

            migrationBuilder.CreateIndex(
                "IX_Notification_PrincipalFK",
                schema: "Core",
                table: "Notifications",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                "IX_Notification_RecordState",
                schema: "Core",
                table: "Notifications",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_PrincipalCategory_RecordState",
                schema: "Core",
                table: "PrincipalCategories",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_PrincipalClaim_Authority",
                schema: "Core",
                table: "PrincipalClaims",
                column: "Authority");

            migrationBuilder.CreateIndex(
                "IX_PrincipalClaim_Key",
                schema: "Core",
                table: "PrincipalClaims",
                column: "Key");

            migrationBuilder.CreateIndex(
                "IX_PrincipalClaims_PrincipalFK",
                schema: "Core",
                table: "PrincipalClaims",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                "IX_PrincipalClaim_RecordState",
                schema: "Core",
                table: "PrincipalClaims",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_PrincipalLogins_PrincipalFK",
                schema: "Core",
                table: "PrincipalLogins",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                "IX_PrincipalLogin_RecordState",
                schema: "Core",
                table: "PrincipalLogins",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_PrincipalProperty_Key",
                schema: "Core",
                table: "PrincipalProperties",
                column: "Key");

            migrationBuilder.CreateIndex(
                "IX_PrincipalProperties_PrincipalFK",
                schema: "Core",
                table: "PrincipalProperties",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                "IX_PrincipalProperty_RecordState",
                schema: "Core",
                table: "PrincipalProperties",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_Principals_CategoryFK",
                schema: "Core",
                table: "Principals",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                "IX_Principals_DataClassificationFK",
                schema: "Core",
                table: "Principals",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                "IX_Principal_RecordState",
                schema: "Core",
                table: "Principals",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_PrincipalTagAssignments_TagFK",
                schema: "Core",
                table: "PrincipalTagAssignments",
                column: "TagFK");

            migrationBuilder.CreateIndex(
                "IX_PrincipalTag_RecordState",
                schema: "Core",
                table: "PrincipalTags",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_PrincipalTag_Title",
                schema: "Core",
                table: "PrincipalTags",
                column: "Title");

            migrationBuilder.CreateIndex(
                "IX_SessionOperation_ActionName",
                schema: "Core",
                table: "SessionOperations",
                column: "ActionName");

            migrationBuilder.CreateIndex(
                "IX_SessionOperation_ControllerName",
                schema: "Core",
                table: "SessionOperations",
                column: "ControllerName");

            migrationBuilder.CreateIndex(
                "IX_SessionOperation_RecordState",
                schema: "Core",
                table: "SessionOperations",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_SessionOperations_SessionFK",
                schema: "Core",
                table: "SessionOperations",
                column: "SessionFK");

            migrationBuilder.CreateIndex(
                "IX_Sessions_PrincipalFK",
                schema: "Core",
                table: "Sessions",
                column: "PrincipalFK");

            migrationBuilder.CreateIndex(
                "IX_Session_RecordState",
                schema: "Core",
                table: "Sessions",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_SystemRoles_DataClassificationFK",
                schema: "Core",
                table: "SystemRoles",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                "IX_SystemRole_Key",
                schema: "Core",
                table: "SystemRoles",
                column: "Key");

            migrationBuilder.CreateIndex(
                "IX_SystemRoles_PrincipalId",
                schema: "Core",
                table: "SystemRoles",
                column: "PrincipalId");

            migrationBuilder.CreateIndex(
                "IX_SystemRole_RecordState",
                schema: "Core",
                table: "SystemRoles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantClaim_Authority",
                schema: "Core",
                table: "TenantClaims",
                column: "Authority");

            migrationBuilder.CreateIndex(
                "IX_TenantClaim_Key",
                schema: "Core",
                table: "TenantClaims",
                column: "Key");

            migrationBuilder.CreateIndex(
                "IX_TenantClaim_RecordState",
                schema: "Core",
                table: "TenantClaims",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantClaims_TenantFK",
                schema: "Core",
                table: "TenantClaims",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfile2TagAssignments_TagFK",
                schema: "Core",
                table: "TenantMemberProfile2TagAssignments",
                column: "TagFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfile2TagAssignments_TenantPrincipalFK",
                schema: "Core",
                table: "TenantMemberProfile2TagAssignments",
                column: "TenantPrincipalFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfileCategory_RecordState",
                schema: "Core",
                table: "TenantMemberProfileCategories",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfileCategory_TenantFK",
                schema: "Core",
                table: "TenantMemberProfileCategories",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfileClaim_Authority",
                schema: "Core",
                table: "TenantMemberProfileClaims",
                column: "Authority");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfileClaim_RecordState",
                schema: "Core",
                table: "TenantMemberProfileClaims",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfileProperty_RecordState",
                schema: "Core",
                table: "TenantMemberProfileProperties",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfileProperty_TenantFK",
                schema: "Core",
                table: "TenantMemberProfileProperties",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfiles_CategoryFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "CategoryFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfiles_DataClassificationFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfile_RecordState",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfiles_SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "SecurityProfileFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfile_TenantFK",
                schema: "Core",
                table: "TenantMemberProfiles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfileTag_RecordState",
                schema: "Core",
                table: "TenantMemberProfileTags",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberProfileTag_Title",
                schema: "Core",
                table: "TenantMemberProfileTags",
                column: "Title");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberSecurityProfile2PermissionAssignments_MemberFK",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "MemberFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberSecurityProfile2PermissionAssignments_PermissionFK",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "PermissionFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberSecurityProfile2PermissionAssignment_RecordState",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberSecurityProfile2PermissionAssignment_TenantFK",
                schema: "Core",
                table: "TenantMemberSecurityProfile2PermissionAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberSecurityProfile_RecordState",
                schema: "Core",
                table: "TenantMemberSecurityProfiles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberSecurityProfiles_SecurityProfileFK",
                schema: "Core",
                table: "TenantMemberSecurityProfiles",
                column: "SecurityProfileFK");

            migrationBuilder.CreateIndex(
                "IX_TenantMemberSecurityProfile_TenantFK",
                schema: "Core",
                table: "TenantMemberSecurityProfiles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantProperty_Key",
                schema: "Core",
                table: "TenantProperties",
                column: "Key");

            migrationBuilder.CreateIndex(
                "IX_TenantProperty_RecordState",
                schema: "Core",
                table: "TenantProperties",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantProperties_TenantFK",
                schema: "Core",
                table: "TenantProperties",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_Tenants_DataClassificationFK",
                schema: "Core",
                table: "Tenants",
                column: "DataClassificationFK");

            migrationBuilder.CreateIndex(
                "IX_Tenant_DisplayName",
                schema: "Core",
                table: "Tenants",
                column: "DisplayName");

            migrationBuilder.CreateIndex(
                "IX_Tenant_Key",
                schema: "Core",
                table: "Tenants",
                column: "Key");

            migrationBuilder.CreateIndex(
                "IX_Tenant_RecordState",
                schema: "Core",
                table: "Tenants",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2PermissionAssignments_PermissionFK",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "PermissionFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2PermissionAssignments_ProfileFK",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "ProfileFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2PermissionAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2PermissionAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfile2PermissionAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2RoleAssignments_ProfileFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "ProfileFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2RoleAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2RoleAssignments_RoleFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "RoleFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2RoleAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2RoleGroupAssignments_ProfileFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "ProfileFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2RoleGroupAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2RoleGroupAssignments_RoleGroupFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "RoleGroupFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile2RoleGroupAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfile2RoleGroupAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfilePermission_RecordState",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfilePermission_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfilePermission_Title",
                schema: "Core",
                table: "TenantSecurityProfilePermissions",
                column: "Title");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileResponsibility_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileResponsibilities",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileResponsibility_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileResponsibilities",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileResponsibility_Title",
                schema: "Core",
                table: "TenantSecurityProfileResponsibilities",
                column: "Title");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole2PermissionAssignments_PermissionFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "PermissionFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole2PermissionAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole2PermissionAssignments_RoleFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "RoleFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole2PermissionAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2PermissionAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole2ResponsibilityAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole2ResponsibilityAssignments_ResponsibilityFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "ResponsibilityFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole2ResponsibilityAssignments_RoleFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "RoleFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole2ResponsibilityAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRole2ResponsibilityAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRoleGroup2RoleAssignments_GroupFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "GroupFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRoleGroup2RoleAssignment_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRoleGroup2RoleAssignments_RoleFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "RoleFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRoleGroup2RoleAssignment_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroup2RoleAssignments",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRoleGroups_ParentId",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRoleGroup_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRoleGroup_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRoleGroup_Title",
                schema: "Core",
                table: "TenantSecurityProfileRoleGroups",
                column: "Title");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole_RecordState",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfileRole_Title",
                schema: "Core",
                table: "TenantSecurityProfileRoles",
                column: "Title");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile_RecordState",
                schema: "Core",
                table: "TenantSecurityProfiles",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile_TenantFK",
                schema: "Core",
                table: "TenantSecurityProfiles",
                column: "TenantFK");

            migrationBuilder.CreateIndex(
                "IX_TenantSecurityProfile_Title",
                schema: "Core",
                table: "TenantSecurityProfiles",
                column: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "DataTokens",
                "Core");

            migrationBuilder.DropTable(
                "ExceptionRecords",
                "Core");

            migrationBuilder.DropTable(
                "MediaMetadatas",
                "Core");

            migrationBuilder.DropTable(
                "Notifications",
                "Core");

            migrationBuilder.DropTable(
                "PrincipalClaims",
                "Core");

            migrationBuilder.DropTable(
                "PrincipalLogins",
                "Core");

            migrationBuilder.DropTable(
                "PrincipalProperties",
                "Core");

            migrationBuilder.DropTable(
                "PrincipalTagAssignments",
                "Core");

            migrationBuilder.DropTable(
                "SessionOperations",
                "Core");

            migrationBuilder.DropTable(
                "SystemRoles",
                "Core");

            migrationBuilder.DropTable(
                "TenantClaims",
                "Core");

            migrationBuilder.DropTable(
                "TenantMemberProfile2TagAssignments",
                "Core");

            migrationBuilder.DropTable(
                "TenantMemberProfileClaims",
                "Core");

            migrationBuilder.DropTable(
                "TenantMemberProfileProperties",
                "Core");

            migrationBuilder.DropTable(
                "TenantMemberSecurityProfile2PermissionAssignments",
                "Core");

            migrationBuilder.DropTable(
                "TenantProperties",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfile2PermissionAssignments",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfile2RoleAssignments",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfile2RoleGroupAssignments",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfileRole2PermissionAssignments",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfileRole2ResponsibilityAssignments",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfileRoleGroup2RoleAssignments",
                "Core");

            migrationBuilder.DropTable(
                "PrincipalTags",
                "Core");

            migrationBuilder.DropTable(
                "Sessions",
                "Core");

            migrationBuilder.DropTable(
                "TenantMemberProfileTags",
                "Core");

            migrationBuilder.DropTable(
                "TenantMemberProfiles",
                "Core");

            migrationBuilder.DropTable(
                "TenantMemberSecurityProfiles",
                "Core");

            migrationBuilder.DropTable(
                "Tenants",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfilePermissions",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfileResponsibilities",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfileRoleGroups",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfileRoles",
                "Core");

            migrationBuilder.DropTable(
                "Principals",
                "Core");

            migrationBuilder.DropTable(
                "TenantMemberProfileCategories",
                "Core");

            migrationBuilder.DropTable(
                "TenantSecurityProfiles",
                "Core");

            migrationBuilder.DropTable(
                "PrincipalCategories",
                "Core");

            migrationBuilder.DropTable(
                "DataClassifications",
                "Core");
        }
    }
}