using Microsoft.AspNetCore.Identity;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Services.Contracts
{
	public interface IAuthService
	{
		Task<IdentityResult> RegisterAsync(RegisterDto model); 
		Task<SignInResult> LoginAsync(LoginDto model);
		Task LogoutAsync();
	}
}
