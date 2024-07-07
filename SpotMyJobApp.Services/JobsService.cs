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
	}
}
