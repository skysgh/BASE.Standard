using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Modules.Core.Infrastructure.Migrations
{
    public partial class PrincipalTagAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrincipalTags_Principals_PrincipalId",
                schema: "Core",
                table: "PrincipalTags");

            migrationBuilder.DropIndex(
                name: "IX_PrincipalTags_PrincipalId",
                schema: "Core",
                table: "PrincipalTags");

            migrationBuilder.DropColumn(
                name: "PrincipalId",
                schema: "Core",
                table: "PrincipalTags");

            migrationBuilder.CreateTable(
                name: "PrincipalTagAssignments",
                schema: "Core",
                columns: table => new
                {
                    PrincipalFK = table.Column<Guid>(nullable: false),
                    TagFK = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(nullable: true),
                    RecordState = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: true),
                    CreatedByPrincipalId = table.Column<string>(nullable: true),
                    LastModifiedOnUtc = table.Column<DateTime>(nullable: true),
                    LastModifiedByPrincipalId = table.Column<string>(nullable: true),
                    DeletedOnUtc = table.Column<DateTime>(nullable: true),
                    DeletedByPrincipalId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrincipalTagAssignments", x => new { x.PrincipalFK, x.TagFK });
                    table.ForeignKey(
                        name: "FK_PrincipalTagAssignments_Principals_PrincipalFK",
                        column: x => x.PrincipalFK,
                        principalSchema: "Core",
                        principalTable: "Principals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrincipalTagAssignments_PrincipalTags_TagFK",
                        column: x => x.TagFK,
                        principalSchema: "Core",
                        principalTable: "PrincipalTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalTagAssignments_TagFK",
                schema: "Core",
                table: "PrincipalTagAssignments",
                column: "TagFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PrincipalTagAssignments",
                schema: "Core");

            migrationBuilder.AddColumn<Guid>(
                name: "PrincipalId",
                schema: "Core",
                table: "PrincipalTags",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrincipalTags_PrincipalId",
                schema: "Core",
                table: "PrincipalTags",
                column: "PrincipalId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrincipalTags_Principals_PrincipalId",
                schema: "Core",
                table: "PrincipalTags",
                column: "PrincipalId",
                principalSchema: "Core",
                principalTable: "Principals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
