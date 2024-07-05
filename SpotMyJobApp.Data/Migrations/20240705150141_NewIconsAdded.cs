using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewIconsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://img.icons8.com/?size=100&id=gUZ2I_4-D9kf&format=png&color=000000");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://img.icons8.com/?size=100&id=AIDAcjXSRdJQ&format=png&color=000000");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://icons8.com/icon/gUZ2I_4-D9kf/money-bag");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://icons8.com/icon/0fy0yPirEETK/production");
        }
    }
}
