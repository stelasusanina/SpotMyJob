using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class fileAddedToJobApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UploadedFileName",
                table: "JobsApplications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadedFileName",
                table: "JobsApplications");
        }
    }
}
