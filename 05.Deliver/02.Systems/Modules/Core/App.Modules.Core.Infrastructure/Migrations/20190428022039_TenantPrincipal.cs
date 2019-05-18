using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class TenantPrincipal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrincipalProfileCategories",
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
                    table.PrimaryKey("PK_PrincipalProfileCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalProfileTags",
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
                    table.PrimaryKey("PK_PrincipalProfileTags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrincipalProfiles",
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
                    Timestamp = table.Column<byte[]>(nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: true),
                    CreatedByPrincipalId = table.Column<string>(nullable: true),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: true),
                    LastModifiedByPrincipalId = table.Column<string>(nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(nullable: true),
                    TenantFK = table.Column<Guid>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "PrincipalProfileTags",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalProfiles",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PrincipalProfileCategories",
                schema: "Core");
        }
    }
}
