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
                name: "Examples",
                schema: "Design",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    DataClassificationFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                schema: "Design",
                table: "Examples",
                columns: new[] { "Id", "DataClassificationFK", "RecordState" },
                values: new object[] { new Guid("212f49e5-572c-018e-9aa8-39ee47b592b8"), 1, 0 });

            migrationBuilder.InsertData(
                schema: "Design",
                table: "Examples",
                columns: new[] { "Id", "DataClassificationFK", "RecordState" },
                values: new object[] { new Guid("092f23e0-8dd1-6119-59d5-39ee47b592b9"), 6, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Example_RecordState",
                schema: "Design",
                table: "Examples",
                column: "RecordState");

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
                name: "Examples",
                schema: "Design");

            migrationBuilder.DropTable(
                name: "Requirements",
                schema: "Design");
        }
    }
}
