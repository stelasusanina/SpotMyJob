using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services
{
	public class JobsService : IJobsService
	{
		private readonly ApplicationDbContext context;
		public JobsService(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<ShortJobOfferDto>> FilterByCategoryAsync(string category)
		{
			if (category == null)
			{
				return null;
			}

			var jobsByCategory = await context.JobOffers
				.Where(jo => jo.JobCategory.Name.ToLower() == category.ToLower())
				.Select(jo => new ShortJobOfferDto
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

			return jobsByCategory;
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

		public async Task<IEnumerable<ShortJobOfferDto>> SearchJobsAsync(string jobTitle)
		{
			if (jobTitle == null)
			{
				return null;
			}

			var jobsBySearch = await context.JobOffers.Where(jo => jo.Title.ToLower().Contains(jobTitle.ToLower()))
				.Select(jo => new ShortJobOfferDto
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

			return jobsBySearch;
		}
	}
}
