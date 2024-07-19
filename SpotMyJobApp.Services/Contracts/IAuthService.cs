using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Services.Contracts
{
	public interface IAuthService
	{
		Task<IdentityResult> RegisterAsync(RegisterDto model);
		Task<SignInResult> LoginAsync(LoginDto model);
		Task LogoutAsync();
		Task<ApplicationUserDto> GetUserDetailsAsync(string userId);
		Task<IEnumerable<JobApplicationDto>> GetUsersJobApplicationsAsync(string userId);
		Task RemoveProfilePhotoAsync(string userId);
		Task UploadProfilePhotoAsync(string userId, string profilePhotoUrl);
	}
}
