using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class X : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionRecords",
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
                    Level = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 32768, nullable: false),
                    Stack = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaMetadatas",
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
                    DataClassificationFK = table.Column<int>(nullable: false),
                    UploadedDateTimeUtc = table.Column<DateTime>(nullable: false),
                    ContentSize = table.Column<long>(nullable: false),
                    MimeType = table.Column<string>(maxLength: 256, nullable: false),
                    SourceFileName = table.Column<string>(maxLength: 256, nullable: false),
                    ContentHash = table.Column<string>(maxLength: 256, nullable: false),
                    LocalName = table.Column<string>(maxLength: 256, nullable: false),
                    LatestScanDateTimeUtc = table.Column<DateTime>(nullable: true),
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
                name: "Notifications",
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
                    Type = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    PrincipalFK = table.Column<Guid>(nullable: false),
                    DateTimeCreatedUtc = table.Column<DateTime>(nullable: false),
                    DateTimeReadUtc = table.Column<DateTime>(nullable: true),
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
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
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
                name: "Principals",
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
                    EnabledBeginningUtc = table.Column<DateTime>(nullable: true),
                    EnabledEndingUtc = table.Column<DateTime>(nullable: true),
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
                name: "PrincipalClaims",
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
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
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
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
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
                name: "PrincipalTags",
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
                    Enabled = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 64, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DisplayOrderHint = table.Column<int>(nullable: false),
                    DisplayStyleHint = table.Column<string>(maxLength: 64, nullable: true),
                    PrincipalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrincipalTags_Principals_PrincipalId",
                        column: x => x.PrincipalId,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
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
                    Enabled = table.Column<bool>(nullable: false),
                    UniqueIdentifier = table.Column<string>(maxLength: 64, nullable: false),
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
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
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
                name: "SessionOperations",
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

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionRecord_LastModifiedByPrincipalId",
                schema: "Core",
                table: "ExceptionRecords",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionRecord_LastModifiedOnUtc",
                schema: "Core",
                table: "ExceptionRecords",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionRecord_RecordState",
                schema: "Core",
                table: "ExceptionRecords",
                column: "RecordState");

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
                name: "IX_MediaMetadata_LastModifiedByPrincipalId",
                schema: "Core",
                table: "MediaMetadatas",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaMetadata_LastModifiedOnUtc",
                schema: "Core",
                table: "MediaMetadatas",
                column: "LastModifiedOnUtc");

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
                name: "IX_Notification_LastModifiedByPrincipalId",
                schema: "Core",
                table: "Notifications",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_LastModifiedOnUtc",
                schema: "Core",
                table: "Notifications",
                column: "LastModifiedOnUtc");

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
                name: "IX_PrincipalCategory_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalCategories",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalCategory_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalCategories",
                column: "LastModifiedOnUtc");

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
                name: "IX_PrincipalClaim_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalClaims",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalClaim_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalClaims",
                column: "LastModifiedOnUtc");

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
                name: "IX_PrincipalLogin_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalLogins",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalLogin_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalLogins",
                column: "LastModifiedOnUtc");

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
                name: "IX_PrincipalProperty_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalProperties",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalProperty_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalProperties",
                column: "LastModifiedOnUtc");

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
                name: "IX_Principal_LastModifiedByPrincipalId",
                schema: "Core",
                table: "Principals",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Principal_LastModifiedOnUtc",
                schema: "Core",
                table: "Principals",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Principal_RecordState",
                schema: "Core",
                table: "Principals",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalTag_LastModifiedByPrincipalId",
                schema: "Core",
                table: "PrincipalTags",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalTag_LastModifiedOnUtc",
                schema: "Core",
                table: "PrincipalTags",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalTags_PrincipalId",
                schema: "Core",
                table: "PrincipalTags",
                column: "PrincipalId");

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
                name: "IX_SessionOperation_LastModifiedByPrincipalId",
                schema: "Core",
                table: "SessionOperations",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionOperation_LastModifiedOnUtc",
                schema: "Core",
                table: "SessionOperations",
                column: "LastModifiedOnUtc");

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
                name: "IX_Session_LastModifiedByPrincipalId",
                schema: "Core",
                table: "Sessions",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_LastModifiedOnUtc",
                schema: "Core",
                table: "Sessions",
                column: "LastModifiedOnUtc");

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
                name: "IX_SystemRole_LastModifiedByPrincipalId",
                schema: "Core",
                table: "SystemRoles",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemRole_LastModifiedOnUtc",
                schema: "Core",
                table: "SystemRoles",
                column: "LastModifiedOnUtc");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "PrincipalTags",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "SessionOperations",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "SystemRoles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Sessions",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Principals",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalCategories",
                schema: "Core");
        }
    }
}
