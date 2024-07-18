using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;
using System.Security.Claims;

namespace SpotMyJobApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly IAuthService authService;

		public AuthController(IAuthService authService, UserManager<ApplicationUser> userManager)
		{
			this.authService = authService;
			this.userManager = userManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await authService.RegisterAsync(model);

			if (result.Succeeded)
			{
				var user = await userManager.FindByEmailAsync(model.Email);

				if (user != null)
				{
					await userManager.AddToRoleAsync(user, Roles.User);
				}

				var userRole = User.FindFirstValue(ClaimTypes.Role);

				return Ok(new { message = "User registered successfully", user.FirstName, user.LastName, user.Id, user.Email, userRole});
			}

			return BadRequest(result.Errors);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var result = await authService.LoginAsync(model);

			if (result.Succeeded)
			{
				var user = await userManager.FindByEmailAsync(model.Email);
				var userRole = User.FindFirstValue(ClaimTypes.Role);
				return Ok(new { message = "Login successful", user.FirstName, user.LastName, user.Id, userRole});
			}

			return Unauthorized(new { message = "Invalid login attempt" });
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await authService.LogoutAsync();
			return Ok(new { message = "Logout successful" });
		}

		[HttpGet("identify")]
		public IActionResult Identify()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (userId == null)
			{
				return NotFound(new { message = "User not found" });
			}

			return Ok(new { userId });
		}

		[HttpGet("profile/userDetails")]
		public async Task<IActionResult> GetUserDetails(string userId)
		{
			if (string.IsNullOrEmpty(userId))
			{
				return NotFound("User not found!");
			}

			var userDetails = await authService.GetUserDetailsAsync(userId);

			if (userDetails == null)
			{
				return NotFound("Details not found!");
			}

			return Ok(userDetails);
		}

		[HttpGet("profile/jobApplications")]
		public async Task<IActionResult> GetUsersJobApplications(string userId)
		{
			if (string.IsNullOrEmpty(userId))
			{
				return NotFound("User not found!");
			}

			var jobApplications = await authService.GetUsersJobApplicationsAsync(userId);

			if (jobApplications == null)
			{
				return NotFound("Job applications not found!");
			}

			return Ok(jobApplications);
		}

		[HttpGet("access-denied")]
		public IActionResult AccessDenied()
		{
			return Forbid();
		}
	}
}
