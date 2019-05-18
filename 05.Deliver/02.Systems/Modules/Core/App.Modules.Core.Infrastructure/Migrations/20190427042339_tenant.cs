using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class tenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
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
                name: "TenantClaims",
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
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
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
                name: "IX_TenantClaim_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantClaims",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantClaim_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantClaims",
                column: "LastModifiedOnUtc");

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
                name: "IX_TenantProperty_Key",
                schema: "Core",
                table: "TenantProperties",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_TenantProperty_LastModifiedByPrincipalId",
                schema: "Core",
                table: "TenantProperties",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantProperty_LastModifiedOnUtc",
                schema: "Core",
                table: "TenantProperties",
                column: "LastModifiedOnUtc");

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
                name: "IX_Tenant_LastModifiedByPrincipalId",
                schema: "Core",
                table: "Tenants",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_LastModifiedOnUtc",
                schema: "Core",
                table: "Tenants",
                column: "LastModifiedOnUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Tenant_RecordState",
                schema: "Core",
                table: "Tenants",
                column: "RecordState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenantClaims",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "TenantProperties",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Tenants",
                schema: "Core");
        }
    }
}
