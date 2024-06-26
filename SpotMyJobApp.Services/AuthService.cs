﻿using Microsoft.AspNetCore.Identity;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		public async Task<IdentityResult> RegisterAsync(RegisterDto model)
		{
			var user = new ApplicationUser { UserName = model.Email, Email = model.Email,
				FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber };
			var result = await userManager.CreateAsync(user, model.Password);

			return result;
		}

		public async Task<SignInResult> LoginAsync(LoginDto model)
		{
			var user = await userManager.FindByEmailAsync(model.Email);
			if (user == null)
			{
				return SignInResult.Failed;
			}

			var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, 
				isPersistent: false, lockoutOnFailure: false);

			return result;
		}

		public async Task LogoutAsync()
		{
			await signInManager.SignOutAsync();
		}
	}
}
