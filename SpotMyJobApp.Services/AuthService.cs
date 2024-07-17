using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly ApplicationDbContext context;

		public AuthService
			(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.context = context;
		}

		public async Task<IdentityResult> RegisterAsync(RegisterDto model)
		{
			var user = new ApplicationUser
			{
				UserName = model.Email,
				Email = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber
			};
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

		public async Task<ApplicationUserDto> GetUserDetailsAsync(string userId)
		{
			var user = await context.Users
				.Where(u => u.Id == userId)
				.Select(u => new ApplicationUserDto
				{
					Id = u.Id,
					FirstName = u.FirstName,
					LastName = u.LastName,
					PhoneNumber = u.PhoneNumber,
					Email = u.Email
				})
				.FirstOrDefaultAsync();

			return user;
		}

		public async Task<IEnumerable<JobApplicationDto>> GetUsersJobApplicationsAsync(string userId)
		{
			var applications = await context.Users
				.Where(u => u.Id == userId)
				.SelectMany(u => u.JobsApplications.Select(ja => new JobApplicationDto
				{
					JobOfferId = ja.JobOfferId,
					JobOfferTitle = ja.JobOffer.Title,
					JobCompanyName = ja.JobOffer.CompanyName,
					UploadedFileName = ja.UploadedFileName,
					Status = ja.Status,
					AppliedOn = ja.AppliedOn.ToString(),
				})).ToListAsync();

			return applications;
		}

	}
}
