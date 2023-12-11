using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeLibraryApp.Migrations
{
    public partial class KeywordLibraryItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Keywords_LibraryItems_LibraryItemId",
                table: "Keywords");

            migrationBuilder.DropIndex(
                name: "IX_Keywords_LibraryItemId",
                table: "Keywords");

            migrationBuilder.DropColumn(
                name: "LibraryItemId",
                table: "Keywords");

            migrationBuilder.CreateTable(
                name: "KeywordLibraryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeywordId = table.Column<int>(type: "int", nullable: false),
                    LibraryItemId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeywordLibraryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeywordLibraryItems_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalTable: "Keywords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KeywordLibraryItems_LibraryItems_LibraryItemId",
                        column: x => x.LibraryItemId,
                        principalTable: "LibraryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b51dff5d-8c65-4df1-b66a-66b5a14037a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "1081ec1b-04a1-4c5f-9d61-481f613caf38");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 9, 10, 38, 47, 495, DateTimeKind.Utc).AddTicks(2952));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 12, 9, 10, 38, 47, 495, DateTimeKind.Utc).AddTicks(2956));

            migrationBuilder.CreateIndex(
                name: "IX_KeywordLibraryItems_KeywordId",
                table: "KeywordLibraryItems",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_KeywordLibraryItems_LibraryItemId",
                table: "KeywordLibraryItems",
                column: "LibraryItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeywordLibraryItems");

            migrationBuilder.AddColumn<int>(
                name: "LibraryItemId",
                table: "Keywords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bd6f20bb-d363-47af-8a48-5624f1568bb0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "5f732ba9-7aa3-4f34-94d1-27262f64e6ff");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 3, 21, 38, 14, 476, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 12, 3, 21, 38, 14, 476, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_LibraryItemId",
                table: "Keywords",
                column: "LibraryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Keywords_LibraryItems_LibraryItemId",
                table: "Keywords",
                column: "LibraryItemId",
                principalTable: "LibraryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
