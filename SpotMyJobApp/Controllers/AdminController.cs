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
	}
}
