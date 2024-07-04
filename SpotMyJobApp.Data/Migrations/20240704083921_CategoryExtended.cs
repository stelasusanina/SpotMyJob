using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryExtended : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "JobCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.flaticon.com/free-icon/education_3976631?term=education&page=1&position=7&origin=tag&related_id=3976631");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://www.flaticon.com/free-icon/healthcare_2382461?term=healthcare&page=1&position=5&origin=search&related_id=2382461");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://www.flaticon.com/free-icon/budget_781831?term=finance&page=1&position=3&origin=search&related_id=781831");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://www.flaticon.com/free-icon/compliant_4252296?term=law&page=1&position=4&origin=search&related_id=4252296");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://www.flaticon.com/free-icon/manufacturing_2821866?term=production&page=1&position=26&origin=search&related_id=2821866");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://www.flaticon.com/free-icon/content_9743201?term=marketing&page=1&position=39&origin=search&related_id=9743201");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "JobCategories");
        }
    }
}
