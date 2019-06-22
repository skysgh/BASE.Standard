using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.KWMODULE.Infrastructure.Data.Db.Migrations
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "KWMODULE");

            migrationBuilder.CreateTable(
                "Examples",
                schema: "KWMODULE",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Examples", x => x.Id); });

            migrationBuilder.CreateTable(
                "LinkedExamples",
                schema: "KWMODULE",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    RecordState = table.Column<int>(),
                    Title = table.Column<string>(),
                    Description = table.Column<string>(nullable: true),
                    DataClassificationFK = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("PK_LinkedExamples", x => x.Id); });

            migrationBuilder.CreateTable(
                "TenantedExamples",
                schema: "KWMODULE",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    TenantFK = table.Column<Guid>(),
                    Title = table.Column<string>(),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_TenantedExamples", x => x.Id); });

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "Examples",
                columns: new[] {"Id", "Description", "RecordState", "Title"},
                values: new object[]
                    {new Guid("26a6ed19-2da9-c401-e486-39ee70ad642c"), "Some Description", 0, "Some Title"});

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "Examples",
                columns: new[] {"Id", "Description", "RecordState", "Title"},
                values: new object[] {new Guid("e6c7aae8-c7c2-e6ed-7bf6-39ee70ad642c"), null, 0, "Another Title"});

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "LinkedExamples",
                columns: new[] {"Id", "DataClassificationFK", "Description", "RecordState", "Timestamp", "Title"},
                values: new object[,]
                {
                    {new Guid("926fa677-04ea-dc0d-d523-39ee70ad642d"), 1, "Some Description", 0, null, "Some Title"},
                    {new Guid("b6509e2e-4058-53c7-258c-39ee70ad642d"), 6, null, 0, null, "Another Title"}
                });

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "TenantedExamples",
                columns: new[] {"Id", "Description", "RecordState", "TenantFK", "Title"},
                values: new object[]
                {
                    new Guid("ee27bb8d-bf02-cd18-8484-39ee70ad642d"), "Some Description", 0,
                    new Guid("00000003-0000-0000-0000-000000000000"), "Some Title"
                });

            migrationBuilder.InsertData(
                schema: "KWMODULE",
                table: "TenantedExamples",
                columns: new[] {"Id", "Description", "RecordState", "TenantFK", "Title"},
                values: new object[]
                {
                    new Guid("c8e49b8c-7393-147d-3ba4-39ee70ad642e"), null, 0,
                    new Guid("00000003-0000-0000-0000-000000000000"), "Another Title"
                });

            migrationBuilder.CreateIndex(
                "IX_Example_RecordState",
                schema: "KWMODULE",
                table: "Examples",
                column: "RecordState");

            migrationBuilder.CreateIndex(
                "IX_TenantedExample_RecordState",
                schema: "KWMODULE",
                table: "TenantedExamples",
                column: "RecordState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Examples",
                "KWMODULE");

            migrationBuilder.DropTable(
                "LinkedExamples",
                "KWMODULE");

            migrationBuilder.DropTable(
                "TenantedExamples",
                "KWMODULE");
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}