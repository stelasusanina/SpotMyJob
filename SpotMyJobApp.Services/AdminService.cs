using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services
{
	public class AdminService : IAdminService
	{
		private readonly ApplicationDbContext context;
		public AdminService(ApplicationDbContext context)
		{
			this.context = context;
		}
		public async Task AddJobOfferAsync(EditAddJobOfferDto model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}

			var jobCategory = await context.JobCategories.FindAsync(model.JobCategoryId);
			if (jobCategory == null)
			{
				throw new ArgumentException("Invalid job category ID.");
			}

			var jobOffer = new JobOffer
			{
				Title = model.Title,
				CompanyName = model.CompanyName,
				CompanyImgUrl = model.CompanyImgUrl,
				CompanyDescription = model.CompanyDescription,
				PostedOn = DateTime.Now,
				Country = model.Country,
				City = model.City,
				JobCategoryId = model.JobCategoryId,
				JobCategory = jobCategory,
				IsFullTime = model.IsFullTime,
				Sections = new List<Section>()
			};

			foreach (var sectionDto in model.Sections)
			{
				var section = new Section
				{
					Name = sectionDto.Name,
					Content = sectionDto.Content,
					JobOffer = jobOffer
				};

				jobOffer.Sections.Add(section);
			}

			await context.JobOffers.AddAsync(jobOffer);
			await context.SaveChangesAsync();
		}
	}
}