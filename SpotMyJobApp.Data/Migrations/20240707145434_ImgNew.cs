using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ImgNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyImgUrl",
                value: "https://babconsult.bg/themes/vreedom18-bingo-child/assets/images/logo.svg");

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompanyImgUrl",
                value: "https://worktalent.com/web/uploads/site_users_company/11/logo/thumb_314x132_Adecco-logo-2-2.png");

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompanyImgUrl",
                value: "https://assets.jobs.bg/assets/logo/2015-10-21/b_55f80568ba99ec7d039e7b858410339f.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CompanyImgUrl",
                value: "https://res.cloudinary.com/dtp3xgopv/image/upload/c_fill,w_300,h_150/v1720363235/thumb_314x132_download_resized_c8mmrl.png");

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CompanyImgUrl",
                value: "https://res.cloudinary.com/dtp3xgopv/image/upload/c_pad,w_300,h_150/v1720363493/thumb_314x132_Adecco-logo-2-2_ez2lzw.png");

            migrationBuilder.UpdateData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CompanyImgUrl",
                value: "https://res.cloudinary.com/dtp3xgopv/image/upload/c_pad,w_300,h_150/v1720363595/b_55f80568ba99ec7d039e7b858410339f_hkmfuy.png");
        }
    }
}
