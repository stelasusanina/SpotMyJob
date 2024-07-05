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
	public class HomeService: IHomeService
	{
		private readonly ApplicationDbContext context;

		public HomeService(ApplicationDbContext context)
		{
			this.context = context;
		}

		public async Task<IEnumerable<JobCategoryDto>> GetJobCategoriesAsync()
		{
			return await context.JobCategories.Select(jc => new JobCategoryDto
			{
				Id = jc.Id,
				Name = jc.Name,
				ImageUrl = jc.ImageUrl
			}).ToListAsync();
		}
	}
}
