using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Education" },
                    { 2, "Healthcare" },
                    { 3, "Finance" },
                    { 4, "Law" },
                    { 5, "Production" },
                    { 6, "Marketing" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
