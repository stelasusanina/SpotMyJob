using Microsoft.AspNetCore.Http;
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
		public async Task<ActionResult<IEnumerable<ShortJobOfferDto>>> GetAllJobs()
		{
			var jobs = await jobsService.GetAllJobsAsync();

			if (jobs == null)
			{
				return BadRequest();
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

		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<ShortJobOfferDto>>> SearchJobs([FromQuery] string jobTitle)
		{
			var jobsBySearch = await jobsService.SearchJobsAsync(jobTitle);

			if (jobsBySearch == null)
			{
				return BadRequest();
			}

			return Ok(jobsBySearch);
		}

		[HttpGet("filter")]
		public async Task<ActionResult<IEnumerable<ShortJobOfferDto>>> FilterByCategory([FromQuery] string category)
		{
			var filteredJobs = await jobsService.FilterByCategoryAsync(category);

			if (filteredJobs == null)
			{
				return BadRequest();
			}

			return Ok(filteredJobs);
		}

		[HttpPost("{jobId}")]
		public async Task<IActionResult> ApplyToJob([FromForm] int jobId, [FromForm] string userId, [FromForm] IFormFile file)
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
	}
}
