using Microsoft.AspNetCore.Identity;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task<IdentityResult> RegisterAsync(RegisterLoginDto model)
		{
			var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
			var result = await userManager.CreateAsync(user, model.Password);

			return result;
		}

		public async Task<SignInResult> LoginAsync(RegisterLoginDto model)
		{
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
