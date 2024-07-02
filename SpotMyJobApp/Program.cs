using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Data;
using SpotMyJobApp.Services.Contracts;
using SpotMyJobApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

var CLIENT_CORS_POLICY_NAME = "CLIENT_CORS_POLICY";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true; // Ensures cookie is accessible only through HTTP requests
	options.Cookie.SameSite = SameSiteMode.Lax; // Adjust as needed for your application's requirements
	options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; // Adjust for HTTPS deployment
	options.Cookie.Domain = "localhost"; // Domain for which the cookie is valid
	options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Cookie expiration time
	options.LoginPath = "/api/auth/login"; // Path where login redirects
	options.AccessDeniedPath = "/api/auth/access-denied"; // Path for access denied redirects
	options.SlidingExpiration = true; // Extend cookie lifetime on each request
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie();

builder.Services.Configure<IdentityOptions>(options =>
{
	options.Password.RequireNonAlphanumeric = false;
	options.Password.RequireDigit = false;
	options.Password.RequiredUniqueChars = 0;
});


builder.Services.AddCors(options =>
{
	options.AddPolicy(CLIENT_CORS_POLICY_NAME,
		builder =>
		{
			builder.WithOrigins("http://localhost:3000")
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials();
		});
});

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(CLIENT_CORS_POLICY_NAME);

app.MapControllers();

app.Run();
