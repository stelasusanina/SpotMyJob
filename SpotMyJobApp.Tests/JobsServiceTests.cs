using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Services;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Tests
{
	public class JobsServiceTests:IDisposable
	{
		private readonly ApplicationDbContext context;
		private readonly JobsService jobsService;

		public JobsServiceTests()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;

			context = new ApplicationDbContext(options);
			jobsService = new JobsService(context);

			SeedDatabase();
		}

		private void SeedDatabase()
		{
			var jobCategories = new List<JobCategory>
			{
				new JobCategory { Id = 1, Name = "IT", ImageUrl = "url1" },
				new JobCategory { Id = 2, Name = "Finance", ImageUrl = "url2" },
				new JobCategory { Id = 3, Name = "Marketing", ImageUrl = "url3" }
			};

			var jobOffers = new List<JobOffer>
			{
				new JobOffer
				{
					Id = 1,
					Title = "Software Developer",
					PostedOn = DateTime.Now.AddDays(-10),
					City = "New York",
					Country = "USA",
					CompanyImgUrl = "img1",
					CompanyName = "Tech",
					IsFullTime = true,
					JobCategoryId = 1,
					JobCategory = jobCategories[0]
				},
				new JobOffer
				{
					Id = 2,
					Title = "Financial Analyst",
					PostedOn = DateTime.Now.AddDays(-5),
					City = "San Francisco",
					Country = "USA",
					CompanyImgUrl = "img2",
					CompanyName = "Tech",
					IsFullTime = false,
					JobCategoryId = 2,
					JobCategory = jobCategories[1]
				}
			};

			context.JobCategories.AddRange(jobCategories);
			context.JobOffers.AddRange(jobOffers);
			context.SaveChanges();
		}

		[Fact]
		public async Task FilterJobsAsync_FiltersByCategory()
		{
			var query = new QueryModel
			{
				Category = "IT",
				OrderBy = "TitleAscending"
			};

			var result = await jobsService.FilterJobsAsync(query);

			var resultList = result.ToList();
			Assert.Single(resultList);
			Assert.Equal("Software Developer", resultList[0].Title);
		}

		[Fact]
		public async Task GetAllJobsAsync_ReturnsAllJobs()
		{
			var result = await jobsService.GetAllJobsAsync();

			var resultList = result.ToList();
			Assert.Equal(2, resultList.Count);
			Assert.Contains(resultList, job => job.Title == "Software Developer");
			Assert.Contains(resultList, job => job.Title == "Financial Analyst");
		}

		[Fact]
		public async Task GetJobDetailsAsync_ReturnsJobDetails()
		{
			var jobId = 1;

			var result = await jobsService.GetJobDetailsAsync(jobId);

			Assert.NotNull(result);
			Assert.Equal("Software Developer", result.Title);
		}

		[Fact]
		public async Task ApplyToJobAsync_AddsJobApplication()
		{
			var jobId = 1;
			var userId = "testUserId";
			var formFile = new FormFile(new MemoryStream(), 0, 0, "file", "resume.pdf");

			var result = await jobsService.ApplyToJobAsync(jobId, userId, formFile);

			Assert.True(result);
			var jobApplication = await context.JobsApplications
				.FirstOrDefaultAsync(ja => ja.JobOfferId == jobId && ja.ApplicationUserId == userId);
			Assert.NotNull(jobApplication);
			Assert.Equal("resume.pdf", jobApplication.UploadedFileName);
		}

		[Fact]
		public async Task HasUserAppliedAsync_ReturnsTrueIfApplied()
		{
			var jobId = 1;
			var userId = "testUserId";
			await context.JobsApplications.AddAsync(new JobApplication
			{
				JobOfferId = jobId,
				ApplicationUserId = userId,
				Status = "Applied",
				UploadedFileName = "resume.pdf",
				AppliedOn = DateTime.Now
			});
			await context.SaveChangesAsync();

			var result = await jobsService.HasUserAppliedAsync(jobId, userId);

			Assert.True(result);
		}

		[Fact]
		public async Task GetAllCountriesAsync_ReturnsDistinctCountries()
		{
			var result = await jobsService.GetAllCountriesAsync();

			var resultList = result.ToList();
			Assert.Contains("USA", resultList);
		}

		public void Dispose()
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}
	}
}
