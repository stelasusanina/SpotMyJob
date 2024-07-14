using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpotMyJobApp.Services;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;
using System.Security.Claims;

namespace SpotMyJobApp.Controllers
{
	[Route("api/home")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly IHomeService homeService;

		public HomeController(IHomeService homeService)
		{
			this.homeService = homeService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<JobCategoryDto>>> GetAllCategories()
		{
			var categories = await homeService.GetJobCategoriesAsync();
			return Ok(categories);
		}
	}
}
