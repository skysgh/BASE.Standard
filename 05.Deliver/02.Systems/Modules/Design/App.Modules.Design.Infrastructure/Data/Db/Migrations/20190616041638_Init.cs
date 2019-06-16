using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Design.Infrastructure.Data.Db.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Design");

            migrationBuilder.CreateTable(
                name: "Requirements",
                schema: "Design",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    ISO25010Quality = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 32768, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_ISO25010Quality",
                schema: "Design",
                table: "Requirements",
                column: "ISO25010Quality");

            migrationBuilder.CreateIndex(
                name: "IX_Requirement_RecordState",
                schema: "Design",
                table: "Requirements",
                column: "RecordState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requirements",
                schema: "Design");
        }
    }
}
