using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class DataTokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataTokens",
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
                    Value = table.Column<string>(maxLength: 32768, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTokens", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataToken_LastModifiedByPrincipalId",
                schema: "Core",
                table: "DataTokens",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_DataToken_LastModifiedOnUtc",
                schema: "Core",
                table: "DataTokens",
                column: "LastModifiedOnUtc");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataTokens",
                schema: "Core");
        }
    }
}
