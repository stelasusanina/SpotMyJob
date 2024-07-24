using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Services
{
	public class JobsService : IJobsService
	{
		private readonly ApplicationDbContext context;
		public JobsService(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<ShortJobOfferDto>> FilterJobsAsync(QueryModel query)
		{
			var jobs = await context.JobOffers
				.Include(j => j.JobCategory)
				.ToListAsync();

			if (!string.IsNullOrEmpty(query.Category))
			{
				var categories = query.Category.Split(',').Select(c => c.Trim()).ToList();
				jobs = jobs.Where(j => categories.Any(category => j.JobCategory.Name.Contains(category, StringComparison.OrdinalIgnoreCase))).ToList();
			}

			if (!string.IsNullOrEmpty(query.Country))
			{
				var countries = query.Country.Split(',').Select(c => c.Trim()).ToList();
				jobs = jobs.Where(j => countries.Any(country => j.Country.Contains(country, StringComparison.OrdinalIgnoreCase))).ToList();
			}

			if (!string.IsNullOrEmpty(query.JobTitle))
			{
				jobs = jobs.Where(j => j.Title.Contains(query.JobTitle, StringComparison.OrdinalIgnoreCase)).ToList();
			}

			switch (query.OrderBy)
			{
				case "TitleAscending":
					jobs = jobs.OrderBy(j => j.Title).ToList();
					break;
				case "TitleDescending":
					jobs = jobs.OrderByDescending(j => j.Title).ToList();
					break;
				case "NewerDate":
					jobs = jobs.OrderByDescending(j => j.PostedOn).ToList();
					break;
				case "OlderDate":
					jobs = jobs.OrderBy(j => j.PostedOn).ToList();
					break;
				default:
					jobs = jobs.OrderBy(j => j.Title).ToList();
					break;
			}

			var filteredJobs = jobs.Select(jo => new ShortJobOfferDto
			{
				Id = jo.Id,
				Title = jo.Title,
				PostedOn = jo.PostedOn,
				City = jo.City,
				Country = jo.Country,
				CompanyImgUrl = jo.CompanyImgUrl,
				IsFullTime = jo.IsFullTime,
				JobCategory = jo.JobCategory.Name
			}).ToList();

			return filteredJobs;
		}

		public async Task<IEnumerable<ShortJobOfferDto>> GetAllJobsAsync()
		{
			var jobs = await context.JobOffers.Select(jo => new ShortJobOfferDto
			{
				Id = jo.Id,
				Title = jo.Title,
				PostedOn = jo.PostedOn,
				City = jo.City,
				Country = jo.Country,
				CompanyImgUrl = jo.CompanyImgUrl,
				IsFullTime = jo.IsFullTime,
				JobCategory = jo.JobCategory.Name
			}).ToListAsync();

			return jobs;
		}

		public async Task<JobOfferDto> GetJobDetailsAsync(int jobId)
		{
			var job = await context.JobOffers.Where(jo => jo.Id == jobId)
				.Select(jo => new JobOfferDto
				{
					Id = jo.Id,
					Title = jo.Title,
					PostedOn = jo.PostedOn,
					City = jo.City,
					Country = jo.Country,
					CompanyName = jo.CompanyName,
					CompanyDescription = jo.CompanyDescription,
					IsFullTime = jo.IsFullTime,
					JobCategory = jo.JobCategory.Name,
					JobApplicationsCount = jo.JobsApplications.Count(),
					Sections = jo.Sections.Where(s => s.JobOfferId == jobId).Select(s => new SectionDto
					{
						Id = s.Id,
						Name = s.Name,
						Content = s.Content
					}).ToList()
				}).FirstOrDefaultAsync();

			if (job == null)
			{
				return null;
			}

			return job;
		}

		public async Task<bool> ApplyToJobAsync(int jobId, string userId, IFormFile IFormFile)
		{
			var job = await context.JobOffers.FindAsync(jobId);
			if (job == null)
			{
				return false;
			}

			var fileName = Path.GetFileName(IFormFile.FileName);

			var jobApplication = new JobApplication
			{
				JobOfferId = jobId,
				ApplicationUserId = userId,
				Status = "Applied",
				UploadedFileName = fileName,
				AppliedOn = DateTime.Now,
			};

			await context.JobsApplications.AddAsync(jobApplication);
			await context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> HasUserAppliedAsync(int jobId, string userId)
		{
			return await context.JobsApplications
								.AnyAsync(ja => ja.JobOfferId == jobId && ja.ApplicationUserId == userId);
		}

		public async Task<IEnumerable<string>> GetAllCountriesAsync()
		{
			var countries = await context.JobOffers.Select(jo => jo.Country)
				.Distinct()
				.ToListAsync();

			return countries;
		}
	}
}
