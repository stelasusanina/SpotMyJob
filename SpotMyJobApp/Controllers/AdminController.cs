using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService adminService;
		public AdminController(IAdminService adminService)
		{
			this.adminService = adminService;
		}

		[HttpPost("addJobOffer")]
		public async Task<IActionResult> AddJobOffer([FromBody] EditAddJobOfferDto model)
		{
			if (model == null)
			{
				return BadRequest("Job offer data is null.");
			}

			await adminService.AddJobOfferAsync(model);
			return Ok("Job offer added successfully.");
		}

		[HttpDelete("deleteJobOffer/{jobOfferId}")]
		public async Task<IActionResult> DeleteJobOffer(int jobOfferId)
		{
			if (jobOfferId <= 0)
			{
				return BadRequest("Invalid job offer ID.");
			}

			bool isDeleted = await adminService.DeleteJobOfferAsync(jobOfferId);

			if (!isDeleted)
			{
				return NotFound("Job offer not found.");
			}

			return Ok("Job offer deleted successfully.");
		}

		[HttpGet("allJobApplications")]
		public async Task<IActionResult> GetAllJobApplications()
		{
			var jobOffers = await adminService.GetAllJobApplicationsAsync();
			if (jobOffers == null)
			{
				return BadRequest("");
			}

			return Ok(jobOffers);
		}

		[HttpPut("changeApplicationStatus")]
		public async Task<IActionResult> ChangeStatusOfApplication([FromForm] string userId, [FromForm] int jobOfferId, [FromForm] string status)
		{
			if (string.IsNullOrEmpty(userId) || jobOfferId <= 0 || string.IsNullOrEmpty(status))
			{
				return BadRequest("Invalid data.");
			}

			await adminService.ChangeStatusOfApplicationAsync(userId, jobOfferId, status);

			return Ok();
		}
	}
}
