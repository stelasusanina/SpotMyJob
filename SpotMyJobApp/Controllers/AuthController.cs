using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService authService;
		public AuthController(IAuthService authService)
		{
			this.authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDto model)
		{
			var result = await authService.RegisterAsync(model);

			if (result.Succeeded)
			{
				return Ok(new { message = "User registered successfully" });
			}

			return BadRequest(result.Errors);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto model)
		{
			var result = await authService.LoginAsync(model);

			if (result.Succeeded)
			{
				return Ok(new { message = "Login successful" });
			}

			return Unauthorized(new { message = "Invalid login attempt" });
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await authService.LogoutAsync();
			return Ok(new { message = "Logout successful" });
		}

		[HttpGet("access-denied")]
		public IActionResult AccessDenied()
		{
			return Forbid();
		}
	}
}
