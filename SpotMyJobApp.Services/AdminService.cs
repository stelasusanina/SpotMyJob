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

		public async Task ChangeStatusOfApplicationAsync(string userId, int jobOfferId, string status)
		{
			var jobApplication = await context.JobsApplications
				.Where(ja => ja.JobOfferId == jobOfferId && ja.ApplicationUserId == userId)
				.FirstOrDefaultAsync();

			if(jobApplication == null)
			{
				return;
			}

			jobApplication.Status = status;
			await context.SaveChangesAsync();
		}

		public async Task<bool> DeleteJobOfferAsync(int jobOfferId)
		{
			var jobOffer = await context.JobOffers.FindAsync(jobOfferId);

			if (jobOffer == null)
			{
				return false;
			}

			context.JobOffers.Remove(jobOffer);
			await context.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<ShortJobOfferDto>> GetAllJobApplicationsAsync()
		{
			var jobs = await context.JobOffers
				.Include(jo => jo.JobsApplications)
				.ThenInclude(ja => ja.Applicant)
				.Select(jo => new ShortJobOfferDto
				{
					Id = jo.Id,
					Title = jo.Title,
					CompanyName = jo.CompanyName,
					Country = jo.Country,
					City = jo.City,
					Users = jo.JobsApplications.Select(ja => new JobApplicationDto
					{
						ApplicationUserId = ja.ApplicationUserId,
						ApplicationUserProfilePhotoUrl = ja.Applicant.ProfilePictureUrl,
						ApplicationUserNames = ja.Applicant.FirstName + " " + ja.Applicant.LastName,
						Status = ja.Status,
						UploadedFileName = ja.UploadedFileName,
						AppliedOn = ja.AppliedOn.ToString()
					}).ToList()
				})
				.ToListAsync();

			return jobs;
		}
	}
}