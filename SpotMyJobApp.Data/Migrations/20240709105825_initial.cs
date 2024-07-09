using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFullTime = table.Column<bool>(type: "bit", nullable: false),
                    CompanyImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobsApplications",
                columns: table => new
                {
                    JobOfferId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobsApplications", x => new { x.JobOfferId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_JobsApplications_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobsApplications_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobOfferId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_JobOffers_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "Id", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "https://img.icons8.com/?size=100&id=jWPjQhx0oPhE&format=png&color=000000", "Education" },
                    { 2, "https://img.icons8.com/?size=100&id=PSyk3ndz4y8Q&format=png&color=000000", "Healthcare" },
                    { 3, "https://img.icons8.com/?size=100&id=gUZ2I_4-D9kf&format=png&color=000000", "Finance" },
                    { 4, "https://img.icons8.com/?size=100&id=ZUwxA3fsWxzF&format=png&color=000000", "Law" },
                    { 5, "https://img.icons8.com/?size=100&id=AIDAcjXSRdJQ&format=png&color=000000", "Production" },
                    { 6, "https://img.icons8.com/?size=100&id=1nBLKCIr03wS&format=png&color=000000", "Marketing" },
                    { 7, "https://img.icons8.com/?size=100&id=108778&format=png&color=000000", "Tourism" },
                    { 8, "https://img.icons8.com/?size=100&id=zFSrLrSD9rtA&format=png&color=000000", "Real Estate" },
                    { 9, "https://img.icons8.com/?size=100&id=119113&format=png&color=000000", "Trade & Sales" },
                    { 10, "https://img.icons8.com/?size=100&id=ljP1BCzecHs6&format=png&color=000000", "Restaurants" }
                });

            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "City", "CompanyDescription", "CompanyImgUrl", "CompanyName", "Country", "IsFullTime", "JobCategoryId", "PostedOn", "Title" },
                values: new object[,]
                {
                    { 1, "Sofia", "As a recruiting agency, we offer you an exceptional job opportunity for a trusted client. They are a leading BPO company and are currently seeking ambitious travel enthusiasts.\r\n\r\nWith a focus on luxury and bespoke travel arrangements, they pride themselves on delivering exceptional service and creating lifelong memories for clients worldwide.", "https://babconsult.bg/themes/vreedom18-bingo-child/assets/images/logo.svg", "BAB consult", "Bulgaria", true, 7, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Travel Advisor with German & English" },
                    { 2, "Sofia", null, "https://worktalent.com/web/uploads/site_users_company/11/logo/thumb_314x132_Adecco-logo-2-2.png", "Adecco", "Bulgaria", true, 8, new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Market Research Analyst (commercial real estate)" },
                    { 3, "Bucharest", null, "https://assets.jobs.bg/assets/logo/2015-10-21/b_55f80568ba99ec7d039e7b858410339f.png", "HT Research", "Romania", true, 2, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Clinical Trial Assistant – CTA" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Content", "JobOfferId", "Name" },
                values: new object[,]
                {
                    { 1, "Assisting clients in planning and booking their travel arrangements. Building and maintaining strong client relationships through effective communication and personalized service. Resolving any issues or concerns that arise before, during, or after travel, ensuring a seamless experience for all clients.", 1, "Responsibilities" },
                    { 2, "Fluency in both German and English (written and spoken) is essential. Excellent communication and customer service skills. Ability to work independently. Basic computer knowledge.", 1, "Requirements" },
                    { 3, "Fully remote position. Paid training and onboarding. Competitive salary and performance-based incentives. Opportunities for professional development and career growth within the company.", 1, "Benefits" },
                    { 4, "Conduct thorough market research on commercial real estate markets, including collecting and analyzing data on various market indicators. Identify trends, patterns and correlations in the data to inform valuation decisions. Utilize statistical models and forecasting techniques to predict future market conditions and property values. Prepare market reports and presentations for clients, highlighting key findings and recommendations. Collaborate with valuation professionals to integrate market research findings into the valuation process. Ensure compliance with industry regulations, professional standards and best practices in market research activities.", 2, "Responsibilities" },
                    { 5, "Master’s/Bachelor’s degree in a relevant field. 1+ years of experience in market research role. Proficiency in Microsoft Excel and PowerPoint. Fluency in English. Excellent research skills, with the ability to gather and interpret data from diverse sources. Effective communication skills, with the ability to present complex information in a clear and concise manner. Familiarity with real estate valuation methodologies and concepts will be considered an advantage.", 2, "Requirements" },
                    { 6, "Vibrant company culture with friendly team and team events. Real estate professionals who will provide you relevant introduction and training. High ethical and professional standards. Open-minded team who will value your opinion. Opportunities for professional growth and advancement. Competitivе remuneration and additional benefits.", 2, "Benefits" },
                    { 7, "Assist Clinical Trial Lead / Project Manager and Clinical Research Associates (CRAs) with accurately updating and maintaining clinical systems that track site compliance and performance within project timelines. Maintenance of Trial Master File - paper and electronic. Assist the clinical team in the preparation, handling, distribution, filing, and archiving of clinical documentation and reports according to the scope of work and standard operating procedures. Manage initial set up and access requests for local sponsor and trial site staff to various study systems. Assist with periodic review of study files for accuracy and completeness. Reviewing and completing central Trial Master file prior to any inspection and provision of documents during inspection. Act as a central contact for the clinical team for designated project communications, correspondence and associated documentation. Tracking and helping with ethics and health authority submissions. Strong written and verbal communication skills including good command of English language. Effective time management and organizational skills. School diploma/certificate or equivalent combination of education, training and experience. Life science degree preferred.", 3, "Responsibilities" },
                    { 8, "Fluent Bulgarian and English language – both written and spoken. Basic knowledge of clinical research regulatory requirements, Good Clinical Practice (GCP) and International Conference on Harmonization (ICH) guidelines. At least 2 years of relevant experience. Adequate university degree is advantage. Problem solving skills. Results and detail-oriented approach to work delivery and output. Ability to prioritize own workloads to meet deadlines. Strong software and computer skills, including MS Office applications.", 3, "Requirements" },
                    { 9, "Chance to work in international company. Opportunity to gain specific know-how. Competitive salary. Excellent remuneration package.", 3, "Benefits" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_JobCategoryId",
                table: "JobOffers",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_JobsApplications_ApplicationUserId",
                table: "JobsApplications",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_JobOfferId",
                table: "Sections",
                column: "JobOfferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "JobsApplications");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "JobCategories");
        }
    }
}
