using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Models;

var builder = WebApplication.CreateBuilder(args);

var CLIENT_CORS_POLICY_NAME = "CLIENT_CORS_POLICY";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
	options.LoginPath = "/api/auth/login";
	options.AccessDeniedPath = "/api/auth/access-denied";
	options.SlidingExpiration = true;
});

// Add CORS
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

builder.Services.AddControllers();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(CLIENT_CORS_POLICY_NAME);

app.Run();
