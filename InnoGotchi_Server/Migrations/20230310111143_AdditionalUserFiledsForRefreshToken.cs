using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnoGotchiServer.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalUserFiledsForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60e0aca-70a0-49cf-83ef-01144e5a0b2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f600c839-e037-43e6-b7dd-49d656d359bf");

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a281f50-2703-41ac-a08a-c7945dcfa539", "697aa8a2-23a8-46a1-9120-8429943a61e4", "Administrator", "ADMINISTRATOR" },
                    { "bc946b8b-c47f-4a79-9507-d3170617b2a9", "66d43101-5ded-46b3-9d7f-c2947a5fad47", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a281f50-2703-41ac-a08a-c7945dcfa539");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc946b8b-c47f-4a79-9507-d3170617b2a9");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e60e0aca-70a0-49cf-83ef-01144e5a0b2d", "9a0e2da3-f11a-4ae6-ae38-c49cc542226b", "Manager", "MANAGER" },
                    { "f600c839-e037-43e6-b7dd-49d656d359bf", "0938667e-8b7b-4801-a821-5f404a9b166c", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
