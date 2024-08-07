﻿using Microsoft.AspNetCore.Identity;
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

				return Ok(new { message = "User registered successfully", user.FirstName, user.LastName, user.Id, user.Email, userRole });
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
				return Ok(new { message = "Login successful", user.FirstName, user.LastName, user.Id, userRole });
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

			return Ok(userId);
		}

		[HttpGet("getRole")]
		public IActionResult GetRole()
		{
			var userRole = User.FindFirstValue(ClaimTypes.Role);

			if (userRole == null)
			{
				return NotFound(new { message = "User not found" });
			}

			return Ok(userRole);

		}

		[HttpGet("myProfile/details")]
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

		[HttpGet("myProfile/jobApplications")]
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

		[HttpPost("myProfile/removeProfilePhoto")]
		public async Task<IActionResult> RemoveProfilePhoto()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (string.IsNullOrEmpty(userId))
			{
				return NotFound("User not found!");
			}

			await authService.RemoveProfilePhotoAsync(userId);
			return Ok("Successfully removed profile photo!");
		}

		[HttpPost("myProfile/uploadProfilePhoto")]
		public async Task<IActionResult> UploadProfilePhoto([FromBody] UploadProfilePhotoDto model)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (string.IsNullOrEmpty(userId))
			{
				return NotFound("User not found!");
			}

			await authService.UploadProfilePhotoAsync(userId, model.ProfilePhotoUrl);
			return Ok("Successfully uploaded profile photo!");
		}

		[HttpGet("access-denied")]
		public IActionResult AccessDenied()
		{
			return Forbid();
		}
	}
}
