using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Services;
using SpotMyJobApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SpotMyJobApp.Tests
{
	public class HomeServiceTests : IDisposable
	{
		private readonly ApplicationDbContext context;
		private readonly HomeService homeService;

		public HomeServiceTests()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabase")
				.Options;
			context = new ApplicationDbContext(options);

			SeedDatabase();

			homeService = new HomeService(context);
		}

		private void SeedDatabase()
		{
			var jobCategories = new List<JobCategory>
			{
				new JobCategory { Id = 1, Name = "IT", ImageUrl = "url1" },
				new JobCategory { Id = 2, Name = "Finance", ImageUrl = "url2" },
				new JobCategory { Id = 3, Name = "Marketing", ImageUrl = "url3" }
			};

			context.JobCategories.AddRange(jobCategories);
			context.SaveChanges();
		}

		[Fact]
		public async Task GetJobCategoriesAsync_ReturnsJobCategories()
		{
			var result = await homeService.GetJobCategoriesAsync();

			var resultList = result.ToList();
			Assert.NotNull(resultList);
			Assert.Equal(3, resultList.Count);
			Assert.Equal("IT", resultList[0].Name);
		}

		public void Dispose()
		{
			context.Database.EnsureDeleted();
			context.Dispose();
		}
	}
}
