using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Data.SeedDb;

namespace SpotMyJobApp.Data
{
	public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{

		}
		
		public DbSet<JobOffer> JobOffers { get; set; }
		public DbSet<JobCategory> JobCategories { get; set; }
		public DbSet<JobApplication> JobsApplications { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new JobCategoryConfig());

			builder.Entity<JobApplication>()
				.HasKey(ja => new { ja.JobOfferId, ja.ApplicationUserId });

			builder.Entity<JobApplication>()
				.HasOne(ja => ja.JobOffer)
				.WithMany(jo => jo.JobsApplications)
				.HasForeignKey(ja => ja.JobOfferId);

			builder.Entity<JobApplication>()
				.HasOne(ja => ja.Applicant)
				.WithMany(a => a.JobsApplications)
				.HasForeignKey(ja => ja.ApplicationUserId);

			base.OnModelCreating(builder);
		}
	}
}
