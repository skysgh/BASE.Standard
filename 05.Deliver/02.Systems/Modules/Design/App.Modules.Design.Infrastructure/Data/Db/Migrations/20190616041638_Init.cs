// Copyright MachineBrains, Inc. 2019

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Design.Infrastructure.Data.Db.Migrations
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "Design");

            migrationBuilder.CreateTable(
                "Requirements",
                schema: "Design",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    RecordState = table.Column<int>(),
                    ISO25010Quality = table.Column<int>(),
                    Title = table.Column<string>(maxLength: 32768),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Requirements", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_Requirement_ISO25010Quality",
                schema: "Design",
                table: "Requirements",
                column: "ISO25010Quality");

            migrationBuilder.CreateIndex(
                "IX_Requirement_RecordState",
                schema: "Design",
                table: "Requirements",
                column: "RecordState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Requirements",
                "Design");
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}