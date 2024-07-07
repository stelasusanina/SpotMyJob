﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpotMyJobApp.Data;

#nullable disable

namespace SpotMyJobApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.JobApplication", b =>
                {
                    b.Property<int>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobOfferId", "ApplicationUserId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("JobsApplications");
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.JobCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "https://img.icons8.com/?size=100&id=jWPjQhx0oPhE&format=png&color=000000",
                            Name = "Education"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "https://img.icons8.com/?size=100&id=gUZ2I_4-D9kf&format=png&color=000000",
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "https://img.icons8.com/?size=100&id=1nBLKCIr03wS&format=png&color=000000",
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "https://img.icons8.com/?size=100&id=ZUwxA3fsWxzF&format=png&color=000000",
                            Name = "Law"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "https://img.icons8.com/?size=100&id=PSyk3ndz4y8Q&format=png&color=000000",
                            Name = "Healthcare"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "https://img.icons8.com/?size=100&id=AIDAcjXSRdJQ&format=png&color=000000",
                            Name = "Production"
                        },
                        new
                        {
                            Id = 10,
                            ImageUrl = "https://img.icons8.com/?size=100&id=ljP1BCzecHs6&format=png&color=000000",
                            Name = "Restaurants"
                        },
                        new
                        {
                            Id = 9,
                            ImageUrl = "https://img.icons8.com/?size=100&id=119113&format=png&color=000000",
                            Name = "Trade & Sales"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "https://img.icons8.com/?size=100&id=zFSrLrSD9rtA&format=png&color=000000",
                            Name = "Real Estate"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "https://img.icons8.com/?size=100&id=108778&format=png&color=000000",
                            Name = "Tourism"
                        });
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyImgUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsFullTime")
                        .HasColumnType("bit");

                    b.Property<int>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("JobOffers");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            City = "Sofia",
                            CompanyImgUrl = "https://worktalent.com/web/uploads/site_users_company/11/logo/thumb_314x132_Adecco-logo-2-2.png",
                            CompanyName = "Adecco",
                            Country = "Bulgaria",
                            IsFullTime = true,
                            JobCategoryId = 8,
                            PostedOn = new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Market Research Analyst (commercial real estate)"
                        },
                        new
                        {
                            Id = 3,
                            City = "Bucharest",
                            CompanyImgUrl = "https://assets.jobs.bg/assets/logo/2015-10-21/b_55f80568ba99ec7d039e7b858410339f.png",
                            CompanyName = "HT Research",
                            Country = "Romania",
                            IsFullTime = true,
                            JobCategoryId = 2,
                            PostedOn = new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Clinical Trial Assistant – CTA"
                        },
                        new
                        {
                            Id = 1,
                            City = "Sofia",
                            CompanyDescription = "As a recruiting agency, we offer you an exceptional job opportunity for a trusted client. They are a leading BPO company and are currently seeking ambitious travel enthusiasts.\r\n\r\nWith a focus on luxury and bespoke travel arrangements, they pride themselves on delivering exceptional service and creating lifelong memories for clients worldwide.",
                            CompanyImgUrl = "https://worktalent.com/web/uploads/site_users_company/236/logo/thumb_314x132_download.png",
                            CompanyName = "BAB consult",
                            Country = "Bulgaria",
                            IsFullTime = true,
                            JobCategoryId = 7,
                            PostedOn = new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Travel Advisor with German & English"
                        });
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Assisting clients in planning and booking their travel arrangements. Building and maintaining strong client relationships through effective communication and personalized service. Resolving any issues or concerns that arise before, during, or after travel, ensuring a seamless experience for all clients.",
                            JobOfferId = 1,
                            Name = "Responsibilities"
                        },
                        new
                        {
                            Id = 4,
                            Content = "Conduct thorough market research on commercial real estate markets, including collecting and analyzing data on various market indicators. Identify trends, patterns and correlations in the data to inform valuation decisions. Utilize statistical models and forecasting techniques to predict future market conditions and property values. Prepare market reports and presentations for clients, highlighting key findings and recommendations. Collaborate with valuation professionals to integrate market research findings into the valuation process. Ensure compliance with industry regulations, professional standards and best practices in market research activities.",
                            JobOfferId = 2,
                            Name = "Responsibilities"
                        },
                        new
                        {
                            Id = 7,
                            Content = "Assist Clinical Trial Lead / Project Manager and Clinical Research Associates (CRAs) with accurately updating and maintaining clinical systems that track site compliance and performance within project timelines. Maintenance of Trial Master File - paper and electronic. Assist the clinical team in the preparation, handling, distribution, filing, and archiving of clinical documentation and reports according to the scope of work and standard operating procedures. Manage initial set up and access requests for local sponsor and trial site staff to various study systems. Assist with periodic review of study files for accuracy and completeness. Reviewing and completing central Trial Master file prior to any inspection and provision of documents during inspection. Act as a central contact for the clinical team for designated project communications, correspondence and associated documentation. Tracking and helping with ethics and health authority submissions. Strong written and verbal communication skills including good command of English language. Effective time management and organizational skills. School diploma/certificate or equivalent combination of education, training and experience. Life science degree preferred.",
                            JobOfferId = 3,
                            Name = "Responsibilities"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Fluency in both German and English (written and spoken) is essential. Excellent communication and customer service skills. Ability to work independently. Basic computer knowledge.",
                            JobOfferId = 1,
                            Name = "Requirements"
                        },
                        new
                        {
                            Id = 5,
                            Content = "Master’s/Bachelor’s degree in a relevant field. 1+ years of experience in market research role. Proficiency in Microsoft Excel and PowerPoint. Fluency in English. Excellent research skills, with the ability to gather and interpret data from diverse sources. Effective communication skills, with the ability to present complex information in a clear and concise manner. Familiarity with real estate valuation methodologies and concepts will be considered an advantage.",
                            JobOfferId = 2,
                            Name = "Requirements"
                        },
                        new
                        {
                            Id = 8,
                            Content = "Fluent Bulgarian and English language – both written and spoken. Basic knowledge of clinical research regulatory requirements, Good Clinical Practice (GCP) and International Conference on Harmonization (ICH) guidelines. At least 2 years of relevant experience. Adequate university degree is advantage. Problem solving skills. Results and detail-oriented approach to work delivery and output. Ability to prioritize own workloads to meet deadlines. Strong software and computer skills, including MS Office applications.",
                            JobOfferId = 3,
                            Name = "Requirements"
                        },
                        new
                        {
                            Id = 3,
                            Content = "Fully remote position. Paid training and onboarding. Competitive salary and performance-based incentives. Opportunities for professional development and career growth within the company.",
                            JobOfferId = 1,
                            Name = "Benefits"
                        },
                        new
                        {
                            Id = 6,
                            Content = "Vibrant company culture with friendly team and team events. Real estate professionals who will provide you relevant introduction and training. High ethical and professional standards. Open-minded team who will value your opinion. Opportunities for professional growth and advancement. Competitivе remuneration and additional benefits.",
                            JobOfferId = 2,
                            Name = "Benefits"
                        },
                        new
                        {
                            Id = 9,
                            Content = "Chance to work in international company. Opportunity to gain specific know-how. Competitive salary. Excellent remuneration package.",
                            JobOfferId = 3,
                            Name = "Benfits"
                        });
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SpotMyJobApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SpotMyJobApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotMyJobApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SpotMyJobApp.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.JobApplication", b =>
                {
                    b.HasOne("SpotMyJobApp.Data.Models.ApplicationUser", "Applicant")
                        .WithMany("JobsApplications")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpotMyJobApp.Data.Data.Models.JobOffer", "JobOffer")
                        .WithMany("JobsApplications")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Applicant");

                    b.Navigation("JobOffer");
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.JobOffer", b =>
                {
                    b.HasOne("SpotMyJobApp.Data.Data.Models.JobCategory", "JobCategory")
                        .WithMany("JobOffers")
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.Section", b =>
                {
                    b.HasOne("SpotMyJobApp.Data.Data.Models.JobOffer", "JobOffer")
                        .WithMany("Sections")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobOffer");
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.JobCategory", b =>
                {
                    b.Navigation("JobOffers");
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Data.Models.JobOffer", b =>
                {
                    b.Navigation("JobsApplications");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("SpotMyJobApp.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("JobsApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
