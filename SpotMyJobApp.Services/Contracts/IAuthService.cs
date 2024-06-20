using Microsoft.AspNetCore.Identity;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Services.Contracts
{
	public interface IAuthService
	{
		Task<IdentityResult> RegisterAsync(RegisterLoginDto model); 
		Task<SignInResult> LoginAsync(RegisterLoginDto model);
		Task LogoutAsync();
	}
}
