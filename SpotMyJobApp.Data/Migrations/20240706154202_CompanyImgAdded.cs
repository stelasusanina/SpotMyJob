using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CompanyImgAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyImgUrl",
                table: "JobOffers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyImgUrl",
                table: "JobOffers");
        }
    }
}
