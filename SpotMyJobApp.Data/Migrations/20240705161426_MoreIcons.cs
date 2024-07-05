using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 7, "https://img.icons8.com/?size=100&id=108778&format=png&color=000000", "Tourism" },
                    { 8, "https://img.icons8.com/?size=100&id=zFSrLrSD9rtA&format=png&color=000000", "Real Estate" },
                    { 9, "https://img.icons8.com/?size=100&id=119113&format=png&color=000000", "Trade & Sales" },
                    { 10, "https://img.icons8.com/?size=100&id=ljP1BCzecHs6&format=png&color=000000", "Restaurants" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
