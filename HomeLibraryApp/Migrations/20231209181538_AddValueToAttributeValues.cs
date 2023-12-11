using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeLibraryApp.Migrations
{
    public partial class AddValueToAttributeValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_Attributes_LibraryItemId",
                table: "AttributeValues");

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "AttributeValues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "bf1bdf0a-1b68-462e-a3c7-49aa20bb90b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e3d5fe4d-09d2-452d-9849-3027f99d0f19");

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 9, 18, 15, 38, 42, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Attributes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 12, 9, 18, 15, 38, 42, DateTimeKind.Utc).AddTicks(5153));

            migrationBuilder.CreateIndex(
                name: "IX_AttributeValues_AttributeId",
                table: "AttributeValues",
                column: "AttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_Attributes_AttributeId",
                table: "AttributeValues",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValues_Attributes_AttributeId",
                table: "AttributeValues");

            migrationBuilder.DropIndex(
                name: "IX_AttributeValues_AttributeId",
                table: "AttributeValues");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "AttributeValues");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValues_Attributes_LibraryItemId",
                table: "AttributeValues",
                column: "LibraryItemId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
