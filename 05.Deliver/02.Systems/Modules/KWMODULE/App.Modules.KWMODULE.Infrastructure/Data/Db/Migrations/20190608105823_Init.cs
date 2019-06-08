using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "KWMODULE");

            migrationBuilder.CreateTable(
                name: "Examples",
                schema: "KWMODULE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkedExamples",
                schema: "KWMODULE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DataClassificationFK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedExamples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenantedExamples",
                schema: "KWMODULE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    TenantFK = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantedExamples", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "Examples",
                columns: new[] { "Id", "Description", "RecordState", "Title" },
                values: new object[] { new Guid("0a027fd1-35f8-da13-8698-39ee48ea1fdf"), "Some Description", 0, "Some Title" });

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "Examples",
                columns: new[] { "Id", "Description", "RecordState", "Title" },
                values: new object[] { new Guid("2e4ef525-4673-c5c5-a9ad-39ee48ea1fdf"), null, 0, "Another Title" });

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "LinkedExamples",
                columns: new[] { "Id", "DataClassificationFK", "Description", "RecordState", "Timestamp", "Title" },
                values: new object[,]
                {
                    { new Guid("7d4426fd-9539-38b1-150f-39ee48ea1fe0"), 1, "Some Description", 0, null, "Some Title" },
                    { new Guid("0084e833-09c5-5198-a877-39ee48ea1fe0"), 6, null, 0, null, "Another Title" }
                });

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "TenantedExamples",
                columns: new[] { "Id", "Description", "RecordState", "TenantFK", "Title" },
                values: new object[] { new Guid("7bdb7f45-9a0c-203a-e3d9-39ee48ea1fe0"), "Some Description", 0, new Guid("00000003-0000-0000-0000-000000000000"), "Some Title" });

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "TenantedExamples",
                columns: new[] { "Id", "Description", "RecordState", "TenantFK", "Title" },
                values: new object[] { new Guid("640d5b99-ab4c-843b-d162-39ee48ea1fe1"), null, 0, new Guid("00000003-0000-0000-0000-000000000000"), "Another Title" });

            migrationBuilder.CreateIndex(
                name: "IX_Example_RecordState",
                schema: "KWMODULE",
                table: "Examples",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                name: "IX_TenantedExample_RecordState",
                schema: "KWMODULE",
                table: "TenantedExamples",
                column: "RecordState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examples",
                schema: "KWMODULE");

            migrationBuilder.DropTable(
                name: "LinkedExamples",
                schema: "KWMODULE");

            migrationBuilder.DropTable(
                name: "TenantedExamples",
                schema: "KWMODULE");
        }
    }
}
