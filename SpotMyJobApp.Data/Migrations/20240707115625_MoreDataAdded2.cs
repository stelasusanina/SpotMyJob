using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpotMyJobApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreDataAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JobOffers",
                columns: new[] { "Id", "City", "CompanyDescription", "CompanyImgUrl", "CompanyName", "Country", "IsFullTime", "JobCategoryId", "PostedOn", "Title" },
                values: new object[,]
                {
                    { 1, "Sofia", "As a recruiting agency, we offer you an exceptional job opportunity for a trusted client. They are a leading BPO company and are currently seeking ambitious travel enthusiasts.\r\n\r\nWith a focus on luxury and bespoke travel arrangements, they pride themselves on delivering exceptional service and creating lifelong memories for clients worldwide.", "https://worktalent.com/web/uploads/site_users_company/236/logo/thumb_314x132_download.png", "BAB consult", "Bulgaria", true, 7, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Travel Advisor with German & English" },
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
                    { 9, "Chance to work in international company. Opportunity to gain specific know-how. Competitive salary. Excellent remuneration package.", 3, "Benfits" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "JobOffers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
