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
			if(model == null)
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
	}
}
