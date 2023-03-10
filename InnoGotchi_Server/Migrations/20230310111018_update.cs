using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnoGotchiServer.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b58fc3-09cc-4bb4-8e9f-916b30b5e2cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eee4dd8-3bf7-4113-b732-9a20086ba547");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e60e0aca-70a0-49cf-83ef-01144e5a0b2d", "9a0e2da3-f11a-4ae6-ae38-c49cc542226b", "Manager", "MANAGER" },
                    { "f600c839-e037-43e6-b7dd-49d656d359bf", "0938667e-8b7b-4801-a821-5f404a9b166c", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e60e0aca-70a0-49cf-83ef-01144e5a0b2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f600c839-e037-43e6-b7dd-49d656d359bf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54b58fc3-09cc-4bb4-8e9f-916b30b5e2cc", "5d5838f6-98ea-4ae6-b92e-d45bb1f550dc", "Manager", "MANAGER" },
                    { "7eee4dd8-3bf7-4113-b732-9a20086ba547", "c13c48cf-1c8f-49a1-9e5f-141cceccc7df", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
