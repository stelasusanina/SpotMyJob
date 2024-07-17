using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;
using System.Security.Claims;

namespace SpotMyJobApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobsController : ControllerBase
	{
		private readonly IJobsService jobsService;
		private readonly UserManager<ApplicationUser> userManager;
		public JobsController(IJobsService jobsService, UserManager<ApplicationUser> userManager)
		{
			this.jobsService = jobsService;
			this.userManager = userManager;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ShortJobOfferDto>>> GetJobs([FromQuery] QueryModel query)
		{
			IEnumerable<ShortJobOfferDto> jobs;

			if (query.Category == null && query.Country == null && query.JobTitle == null && query.OrderBy == null)
			{
				jobs = await jobsService.GetAllJobsAsync();
			}
			else
			{
				jobs = await jobsService.FilterJobsAsync(query);
			}

			if (jobs == null || !jobs.Any())
			{
				return NotFound("No jobs found.");
			}

			return Ok(jobs);
		}

		[HttpGet("{jobId}")]
		public async Task<ActionResult<JobOfferDto>> GetJobDetails(int jobId)
		{
			var job = await jobsService.GetJobDetailsAsync(jobId);

			if (job == null)
			{
				return BadRequest();
			}

			return Ok(job);
		}

		[HttpPost("{jobId}")]
		[Authorize]
		public async Task<IActionResult> ApplyToJob(int jobId, [FromForm] string userId, [FromForm] IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				return BadRequest("No file uploaded.");
			}
			var result = await jobsService.ApplyToJobAsync(jobId, userId, file);

			if (!result)
			{
				return NotFound("Application failed.");
			}

			return Ok("Application successful.");
		}

		[HttpGet("{jobId}/hasApplied")]
		public async Task<IActionResult> HasUserApplied(int jobId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return BadRequest();
			}

			var hasApplied = await jobsService.HasUserAppliedAsync(jobId, userId);
			return Ok(new { hasApplied });
		}

		[HttpGet("countries")]
		public async Task<ActionResult<IEnumerable<string>>> GetAllCountries()
		{
			var countries = await jobsService.GetAllCountriesAsync();

			if (countries == null || !countries.Any())
			{
				return BadRequest("No countries found.");
			}

			return Ok(countries);
		}
	}
}
