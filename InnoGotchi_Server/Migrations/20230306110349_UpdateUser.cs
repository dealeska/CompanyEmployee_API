using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnoGotchiServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06646989-3d75-428c-aeb6-d4b981707278");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e695453d-1a6f-44fb-a203-dcfa6117a197");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54b58fc3-09cc-4bb4-8e9f-916b30b5e2cc", "5d5838f6-98ea-4ae6-b92e-d45bb1f550dc", "Manager", "MANAGER" },
                    { "7eee4dd8-3bf7-4113-b732-9a20086ba547", "c13c48cf-1c8f-49a1-9e5f-141cceccc7df", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54b58fc3-09cc-4bb4-8e9f-916b30b5e2cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7eee4dd8-3bf7-4113-b732-9a20086ba547");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06646989-3d75-428c-aeb6-d4b981707278", "ea14e0f5-9247-4c32-be71-ad3a7ecf3ee3", "Manager", "MANAGER" },
                    { "e695453d-1a6f-44fb-a203-dcfa6117a197", "937040e2-e6f9-484a-a69e-69717139eb11", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
