using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using SpotMyJobApp.Data;
using SpotMyJobApp.Data.Data.Models;
using SpotMyJobApp.Data.Models;
using SpotMyJobApp.Services;
using SpotMyJobApp.Services.Dtos;

namespace SpotMyJobApp.Tests
{
	public class AuthServiceTests
	{
		private readonly AuthService authService;
		private readonly Mock<UserManager<ApplicationUser>> mockUserManager;
		private readonly Mock<SignInManager<ApplicationUser>> mockSignInManager;
		private readonly ApplicationDbContext context;

		public AuthServiceTests()
		{
			var options = new DbContextOptionsBuilder<ApplicationDbContext>()
				.UseInMemoryDatabase(databaseName: "SpotMyJobAppTest")
				.Options;

			context = new ApplicationDbContext(options);

			mockUserManager = new Mock<UserManager<ApplicationUser>>(
				new Mock<IUserStore<ApplicationUser>>().Object,
				new Mock<IOptions<IdentityOptions>>().Object,
				new Mock<IPasswordHasher<ApplicationUser>>().Object,
				new IUserValidator<ApplicationUser>[0],
				new IPasswordValidator<ApplicationUser>[0],
				new Mock<ILookupNormalizer>().Object,
				new Mock<IdentityErrorDescriber>().Object,
				new Mock<IServiceProvider>().Object,
				new Mock<ILogger<UserManager<ApplicationUser>>>().Object);

			mockSignInManager = new Mock<SignInManager<ApplicationUser>>(
				mockUserManager.Object,
				new HttpContextAccessor(),
				new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
				new Mock<IOptions<IdentityOptions>>().Object,
				new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
				new Mock<Microsoft.AspNetCore.Authentication.IAuthenticationSchemeProvider>().Object
				);

			authService = new AuthService(mockUserManager.Object, mockSignInManager.Object, context);
		}

		[Fact]
		public async Task RegisterAsync_ReturnsIdentityResult()
		{
			var model = new RegisterDto
			{
				Email = "testuser@example.com",
				FirstName = "Test",
				LastName = "User",
				PhoneNumber = "1234567890",
				Password = "Password123!"
			};

			mockUserManager.Setup(um => um.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
				.ReturnsAsync(IdentityResult.Success);

			var result = await authService.RegisterAsync(model);

			Assert.True(result.Succeeded);
			mockUserManager.Verify(um => um.CreateAsync(It.Is<ApplicationUser>(u =>
				u.Email == model.Email &&
				u.FirstName == model.FirstName &&
				u.LastName == model.LastName &&
				u.PhoneNumber == model.PhoneNumber), model.Password), Times.Once);
		}

		[Fact]
		public async Task LoginAsync_ReturnsSignInResult()
		{
			var model = new LoginDto
			{
				Email = "testuser@example.com",
				Password = "Password123!"
			};

			var user = new ApplicationUser
			{
				Email = model.Email,
				UserName = model.Email
			};

			mockUserManager.Setup(um => um.FindByEmailAsync(model.Email))
				.ReturnsAsync(user);

			mockSignInManager.Setup(sm => sm.PasswordSignInAsync(model.Email, model.Password, false, false))
				.ReturnsAsync(SignInResult.Success);

			var result = await authService.LoginAsync(model);

			Assert.Equal(SignInResult.Success, result);
			mockUserManager.Verify(um => um.FindByEmailAsync(model.Email), Times.Once);
			mockSignInManager.Verify(sm => sm.PasswordSignInAsync(model.Email, model.Password, false, false), Times.Once);
		}

		[Fact]
		public async Task GetUserDetailsAsync_ReturnsCorrectData()
		{
			var userId = "n85do-dd-oij8-2356d";
			var user = new ApplicationUser
			{
				Id = userId,
				FirstName = "Test",
				LastName = "User",
				PhoneNumber = "1234567890",
				Email = "testuser@example.com",
				ProfilePictureUrl = "http://example.com/profile.jpg"
			};

			context.Users.Add(user);
			context.SaveChanges();

			var result = await authService.GetUserDetailsAsync(userId);

			Assert.NotNull(result);
			Assert.Equal(userId, result.Id);
			Assert.Equal("Test", result.FirstName);
			Assert.Equal("User", result.LastName);
			Assert.Equal("1234567890", result.PhoneNumber);
			Assert.Equal("testuser@example.com", result.Email);
			Assert.Equal("http://example.com/profile.jpg", result.ProfilePictureUrl);
		}

		[Fact]
		public async Task GetUsersJobApplicationsAsync_ReturnsApplicationsOfTheRightUser()
		{
			var userId = "4587-h6yd-47d8-543r";
			var user = new ApplicationUser
			{
				Id = userId,
				FirstName = "Test",
				LastName = "User",
				PhoneNumber = "1234567890",
				Email = "testuser@example.com",
				ProfilePictureUrl = "http://example.com/profile.jpg"
			};

			var jobOffer = new JobOffer
			{
				Id = 1,
				Title = "Software Developer",
				CompanyName = "Tech",
				City = "Sofia",
				Country = "Bulgaria",
				CompanyImgUrl = "http://example.com/company.jpg"
			};

			var jobApplication = new JobApplication
			{
				JobOfferId = jobOffer.Id,
				JobOffer = jobOffer,
				ApplicationUserId = userId,
				UploadedFileName = "resume.pdf",
				Status = "Applied",
				AppliedOn = DateTime.Now
			};

			context.JobOffers.Add(jobOffer);
			context.JobsApplications.Add(jobApplication);
			context.Users.Add(user);
			context.SaveChanges();

			var result = await authService.GetUsersJobApplicationsAsync(userId);

			Assert.NotNull(result);
			var applicationDtos = result.ToList();
			Assert.Equal(jobApplication.JobOfferId, applicationDtos[0].JobOfferId);
			Assert.Equal(jobOffer.Title, applicationDtos[0].JobOfferTitle);
			Assert.Equal(jobOffer.CompanyName, applicationDtos[0].JobCompanyName);
			Assert.Equal(jobApplication.UploadedFileName, applicationDtos[0].UploadedFileName);
			Assert.Equal(jobApplication.Status, applicationDtos[0].Status);
			Assert.Equal(jobApplication.AppliedOn.ToString(), applicationDtos[0].AppliedOn);
		}

		[Fact]
		public async Task RemoveProfilePhotoAsync_RemovesProfilePhoto()
		{
			var userId = "testUserId";
			var user = new ApplicationUser
			{
				Id = userId,
				FirstName = "Test",
				LastName = "User",
				PhoneNumber = "1234567890",
				Email = "testuser@example.com",
				ProfilePictureUrl = "http://example.com/profile.jpg"
			};

			context.Users.Add(user);
			await context.SaveChangesAsync();

			await authService.RemoveProfilePhotoAsync(userId);

			var updatedUser = await context.Users.FindAsync(userId);
			Assert.NotNull(updatedUser);
			Assert.Null(updatedUser.ProfilePictureUrl);
		}

		[Fact]
		public async Task UploadProfilePhotoAsync_UpdatesProfilePhoto()
		{
			var userId = "210l-juy67-5877-f45e";
			var user = new ApplicationUser
			{
				Id = userId,
				FirstName = "Test",
				LastName = "User",
				PhoneNumber = "1234567890",
				Email = "testuser@example.com"
			};

			context.Users.Add(user);
			await context.SaveChangesAsync();

			var profilePhotoUrl = "http://example.com/newprofile.jpg";

			await authService.UploadProfilePhotoAsync(userId, profilePhotoUrl);

			var updatedUser = await context.Users.FindAsync(userId);
			Assert.NotNull(updatedUser);
			Assert.Equal(profilePhotoUrl, updatedUser.ProfilePictureUrl);
		}
	}
}
