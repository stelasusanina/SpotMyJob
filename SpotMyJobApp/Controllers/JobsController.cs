using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JobsController : ControllerBase
	{
		private readonly IJobsService jobsService;
		public JobsController(IJobsService jobsService)
		{
			this.jobsService = jobsService;
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
		public async Task<ActionResult<IEnumerable<ShortJobOfferDto>>> SearchJobs([FromQuery]string jobTitle)
		{
			var jobsBySearch = await jobsService.SearchJobsAsync(jobTitle);

			if (jobsBySearch == null)
			{
				return BadRequest();
			}

			return Ok(jobsBySearch);
		}
	}
}
