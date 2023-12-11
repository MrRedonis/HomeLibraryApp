using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeLibraryApp.Migrations
{
    public partial class Image : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Attributes");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "LibraryItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AttributeValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeId = table.Column<int>(type: "int", nullable: false),
                    LibraryItemId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeValues_Attributes_LibraryItemId",
                        column: x => x.LibraryItemId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeValues_LibraryItems_LibraryItemId",
                        column: x => x.LibraryItemId,
                        principalTable: "LibraryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f0ef606b-3925-4e24-abdf-57c8d3bf5ab4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "691d381e-e3dd-4e6a-a8b0-3031595d2483");

            migrationBuilder.InsertData(
                table: "Attributes",
                columns: new[] { "Id", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 3, 21, 14, 15, 760, DateTimeKind.Utc).AddTicks(945), "Liczba stron" },
                    { 2, new DateTime(2023, 12, 3, 21, 14, 15, 760, DateTimeKind.Utc).AddTicks(948), "Numer ISBN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibraryItems_ImageId",
                table: "LibraryItems",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_LibraryItemId",
                table: "AttributeValues",
                column: "LibraryItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryItems_Images_ImageId",
                table: "LibraryItems",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryItems_Images_ImageId",
                table: "LibraryItems");

            migrationBuilder.DropTable(
                name: "AttributeValues");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_LibraryItems_ImageId",
                table: "LibraryItems");

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "LibraryItems");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "Attributes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f3de0011-25a8-4d0f-9e86-256b0956e841");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9a5c7f84-d029-4372-937a-ed2b8cdbdaef");
        }
    }
}
