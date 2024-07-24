using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services;
using SpotMyJobApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Tests
{
	public class AdminServiceTests
	{
		private readonly ApplicationDbContext context;
		private readonly AdminService adminService;

		public AdminServiceTests()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;
			context = new ApplicationDbContext(options);

			adminService = new AdminService(context);
		}

		[Fact]
		public async Task AddJobOfferAsync_AddsJobOffer()
		{
			var jobCategory = new JobCategory { Id = 2, Name = "Software", ImageUrl= "http://example.com/icon.jpg" };
			await context.JobCategories.AddAsync(jobCategory);
			await context.SaveChangesAsync();

			var model = new AddJobOfferDto
			{
				Title = "Software Developer",
				CompanyName = "Tech",
				CompanyImgUrl = "http://example.com/logo.png",
				CompanyDescription = "Leading tech company",
				Country = "USA",
				City = "New York",
				JobCategoryId = jobCategory.Id,
				IsFullTime = true,
				Sections = new List<SectionDto>
				{
					new SectionDto { Name = "Requirements", Content = "Must know C#" }
				}
			};

			await adminService.AddJobOfferAsync(model);

			var jobOffer = await context.JobOffers.Include(jo => jo.Sections).FirstOrDefaultAsync();
			Assert.NotNull(jobOffer);
			Assert.Equal("Software Developer", jobOffer.Title);
			Assert.Equal("Tech", jobOffer.CompanyName);
			Assert.Equal("USA", jobOffer.Country);
		}

		[Fact]
		public async Task ChangeStatusOfApplicationAsync_ChangesStatus()
		{
			var userId = "g543-985p-iu96-97-20l8";
			var jobOfferId = 5;

			var jobApplication = new JobApplication
			{
				JobOfferId = jobOfferId,
				ApplicationUserId = userId,
				Status = "Applied",
				UploadedFileName = "CV.pdf"
			};

			await context.JobsApplications.AddAsync(jobApplication);
			await context.SaveChangesAsync();

			await adminService.ChangeStatusOfApplicationAsync(userId, jobOfferId, "Completed");

			var updatedApplication = await context.JobsApplications
				.FirstOrDefaultAsync(a => a.ApplicationUserId == userId && a.JobOfferId == jobOfferId);

			Assert.NotNull(updatedApplication);
			Assert.Equal("Completed", updatedApplication.Status);
		}


		[Fact]
		public async Task DeleteJobOfferAsync_DeletesJobOffer()
		{
			var jobCategory = new JobCategory { Id = 4, Name = "Software", ImageUrl = "http://example.com/icon.jpg" };
			
			var jobOffer = new JobOffer
			{
				Id = 1,
				Title = "Software Developer",
				CompanyName = "Tech",
				CompanyImgUrl = "http://example.com/logo.png",
				CompanyDescription = "Leading tech company",
				Country = "USA",
				City = "New York",
				JobCategoryId = jobCategory.Id,
				IsFullTime = true,
			};

			await context.JobCategories.AddAsync(jobCategory);
			await context.JobOffers.AddAsync(jobOffer);
			await context.SaveChangesAsync();

			var result = await adminService.DeleteJobOfferAsync(jobOffer.Id);

			Assert.True(result);
			var deletedJobOffer = await context.JobOffers.FindAsync(jobOffer.Id);
			Assert.Null(deletedJobOffer);
		}

		[Fact]
		public async Task GetAllJobApplicationsAsync_ReturnsJobApplications()
		{
			var userId = "testUserId";
			var jobCategory = new JobCategory { Id = 3, Name = "Software", ImageUrl = "http://example.com/icon.jpg" };

			var jobOffer = new JobOffer
			{
				Id = 1,
				Title = "Software Developer",
				CompanyName = "Tech",
				CompanyImgUrl = "http://example.com/logo.png",
				CompanyDescription = "Leading tech company",
				Country = "USA",
				City = "New York",
				JobCategoryId = jobCategory.Id,
				IsFullTime = true,
			};

			var user = new ApplicationUser
			{
				Id = userId,
				FirstName = "Test",
				LastName = "User",
				ProfilePictureUrl = "http://example.com/profile.jpg"
			};
			var jobApplication = new JobApplication
			{
				JobOfferId = jobOffer.Id,
				ApplicationUserId = userId,
				Applicant = user,
				Status = "In-progress",
				UploadedFileName = "resume.pdf",
				AppliedOn = DateTime.Now
			};

			await context.JobCategories.AddAsync(jobCategory);
			await context.JobOffers.AddAsync(jobOffer);
			await context.Users.AddAsync(user);
			await context.JobOffers.AddAsync(jobOffer);
			await context.JobsApplications.AddAsync(jobApplication);
			await context.SaveChangesAsync();

			var result = await adminService.GetAllJobApplicationsAsync();

			Assert.NotNull(result);
			var jobOffers = result.ToList();
			Assert.Equal("Software Developer", jobOffers[0].Title);
			Assert.Single(jobOffers[0].Users);
			Assert.Equal("Test User", jobOffers[0].Users[0].ApplicationUserNames);
			Assert.Equal("In-progress", jobOffers[0].Users[0].Status);
		}
	}
}
