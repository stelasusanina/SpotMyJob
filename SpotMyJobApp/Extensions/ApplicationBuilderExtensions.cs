using Microsoft.AspNetCore.Identity;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Data.Models;

namespace SpotMyJobApp.Extensions
{
	public static class ApplicationBuilderExtensions
	{
		public static async Task CreateRolesAsync(this IApplicationBuilder app)
		{
			using var scope = app.ApplicationServices.CreateScope();
			var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
			var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

			if (dbContext.Users.FirstOrDefault(u => u.Email == "stela1234@gmail.com") == null
				&& dbContext.Users.FirstOrDefault(u => u.Email == "admin@admin.com") == null)
			{
				await SeedUsersAsync(userManager);
			}

			if (userManager != null && roleManager != null)
			{
				var adminRole = new IdentityRole(Roles.Admin);
				var userRole = new IdentityRole(Roles.User);

				await roleManager.CreateAsync(adminRole);
				await roleManager.CreateAsync(userRole);

				var user = await userManager.FindByEmailAsync("stela1234@gmail.com");

				if (user != null)
				{
					await userManager.AddToRoleAsync(user, userRole.Name);
				}

				var admin = await userManager.FindByEmailAsync("admin@admin.com");

				if (admin != null)
				{
					await userManager.AddToRoleAsync(admin, adminRole.Name);
				}
			}
		}

		private async static Task SeedUsersAsync(UserManager<ApplicationUser> userManager)
		{
			var user = new ApplicationUser()
			{
				Id = "00359143-b644-4d40-ad75-b35df9341f0b",
				FirstName = "Stela",
				LastName = "Susanina",
				Email = "stela1234@gmail.com",
				UserName = "stela1234@gmail.com",
			};

			var admin = new ApplicationUser()
			{
				Id = "9a2f0ce7-97a9-4806-a706-5e239efd4dd2",
				FirstName = "Admin",
				LastName = "Admin",
				Email = "admin@admin.com",
				UserName = "admin@admin.com",
			};

			await userManager.CreateAsync(user, "sS123...");
			await userManager.CreateAsync(admin, "aA123...");
		}
	}
}
