using Microsoft.AspNetCore.Http;
using SpotMyJobApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMyJobApp.Services.Contracts
{
	public interface IJobsService
	{
		Task<IEnumerable<ShortJobOfferDto>> GetAllJobsAsync();
		Task<JobOfferDto> GetJobDetailsAsync(int jobId);
		Task<IEnumerable<ShortJobOfferDto>> SearchJobsAsync(string jobTitle);
		Task<IEnumerable<ShortJobOfferDto>> FilterByCategoryAsync (string category);
		Task<string> ApplyToJobAsync(int jobId, string userId, IFormFile IFormFile);
		Task<bool> HasUserAppliedAsync(int jobId, string userId);
	}
}
