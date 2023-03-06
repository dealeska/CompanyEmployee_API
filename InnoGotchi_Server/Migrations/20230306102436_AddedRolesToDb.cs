using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InnoGotchiServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06646989-3d75-428c-aeb6-d4b981707278", "ea14e0f5-9247-4c32-be71-ad3a7ecf3ee3", "Manager", "MANAGER" },
                    { "e695453d-1a6f-44fb-a203-dcfa6117a197", "937040e2-e6f9-484a-a69e-69717139eb11", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06646989-3d75-428c-aeb6-d4b981707278");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e695453d-1a6f-44fb-a203-dcfa6117a197");
        }
    }
}
