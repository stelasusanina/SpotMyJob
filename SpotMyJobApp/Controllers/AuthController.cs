using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterLoginDto model)
		{
			var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
			var result = await userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				return Ok(new { message = "User registered successfully" });
			}

			return BadRequest(result.Errors);
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] RegisterLoginDto model)
		{
			var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

			if (result.Succeeded)
			{
				return Ok(new { message = "Login successful" });
			}

			return Unauthorized(new { message = "Invalid login attempt" });
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return Ok(new { message = "Logout successful" });
		}

		[HttpGet("access-denied")]
		public IActionResult AccessDenied()
		{
			return Forbid();
		}
	}
}
