using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SectionNameAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Section",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Section");
        }
    }
}
