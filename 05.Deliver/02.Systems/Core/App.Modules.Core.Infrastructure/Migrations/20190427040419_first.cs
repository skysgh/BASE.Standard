using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class first : Migration
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
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    CreatedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: false),
                    LastModifiedByPrincipalId = table.Column<string>(maxLength: 36, nullable: false),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(maxLength: 36, nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_DataClassification_LastModifiedByPrincipalId",
                schema: "Core",
                table: "DataClassifications",
                column: "LastModifiedByPrincipalId");

            migrationBuilder.CreateIndex(
                name: "IX_DataClassification_LastModifiedOnUtc",
                schema: "Core",
                table: "DataClassifications",
                column: "LastModifiedOnUtc");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataClassifications",
                schema: "Core");
        }
    }
}
