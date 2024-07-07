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
	options.Cookie.HttpOnly = false; 
	options.Cookie.SameSite = SameSiteMode.None; 
	options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest; 
	options.Cookie.Domain = "localhost";
	options.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
	options.LoginPath = "/api/auth/login"; 
	options.AccessDeniedPath = "/api/auth/access-denied"; 
	options.SlidingExpiration = true; 
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
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IJobsService, JobsService>();

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
