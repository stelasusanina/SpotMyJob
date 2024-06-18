using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data.Models;

namespace SpotMyJobApp.Data
{
	public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{

		}
	}
}
