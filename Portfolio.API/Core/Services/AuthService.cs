using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Portfolio.API.Core.Dtos.Auth;
using Portfolio.API.Core.Dtos.General;
using Portfolio.API.Core.Entities;
using Portfolio.API.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Portfolio.API.Core.Services
{
	public class AuthService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ILogService logService, IConfiguration configuration) : IAuthService
	{
		public async Task<UserInfoResult?> GetUserDetailsByUserNameAsync(string userName)
		{
			var user = await userManager.FindByNameAsync(userName);
			if (user is null)
				return null;

			var roles = await userManager.GetRolesAsync(user);
			var userInfo = GenerateUserInfoObject(user, roles);
			return userInfo;
		}

		public async Task<IEnumerable<string>> GetUsernamesListAsync()
		{
			var userNames = await userManager.Users
				.Select(q => q.UserName)
				.ToListAsync();

			return userNames;
		}

		public async Task<IEnumerable<UserInfoResult>> GetUsersListAsync()
		{
			var users = await userManager.Users.ToListAsync();

			List<UserInfoResult> userInfoResults = [];

			foreach (var user in users)
			{
				var roles = await userManager.GetRolesAsync(user);
				var userInfo = GenerateUserInfoObject(user, roles);
				userInfoResults.Add(userInfo);
			}

			return userInfoResults;
		}

		public async Task<LoginServiceResponseDto?> LoginAsync(LoginDto loginDto)
		{
			// Find user with username
			var user = await userManager.FindByNameAsync(loginDto.UserName);
			if (user is null)
				return null;

			// check password of user
			var isPasswordCorrect = await userManager.CheckPasswordAsync(user, loginDto.Password);
			if (!isPasswordCorrect)
				return null;

			// Return Token and userInfo to front-end
			var newToken = await GenerateJWTTokenAsync(user);
			var roles = await userManager.GetRolesAsync(user);
			var userInfo = GenerateUserInfoObject(user, roles);
			await logService.SaveNewLog(user.UserName, "New Login");

			return new LoginServiceResponseDto()
			{
				NewToken = newToken,
				UserInfo = userInfo
			};
		}

		public async Task<LoginServiceResponseDto?> TokenAsync(TokenDto tokenDto)
		{
			ClaimsPrincipal handler = new JwtSecurityTokenHandler().ValidateToken(tokenDto.Token, new TokenValidationParameters()
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidIssuer = configuration["JWT:ValidIssuer"],
				ValidAudience = configuration["JWT:ValidAudience"],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
			}, out SecurityToken securityToken);

			string decodedUserName = handler.Claims.First(q => q.Type == ClaimTypes.Name).Value;
			if (decodedUserName is null)
				return null;

			var user = await userManager.FindByNameAsync(decodedUserName);
			if (user is null)
				return null;

			var newToken = await GenerateJWTTokenAsync(user);
			var roles = await userManager.GetRolesAsync(user);
			var userInfo = GenerateUserInfoObject(user, roles);
			await logService.SaveNewLog(user.UserName, "New Token Generated");

			return new LoginServiceResponseDto()
			{
				NewToken = newToken,
				UserInfo = userInfo
			};
		}

		public async Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto)
		{
			var isExistsUser = await userManager.FindByNameAsync(registerDto.UserName);
			if (isExistsUser is not null)
				return new GeneralServiceResponseDto()
				{
					IsSucceed = false,
					StatusCode = 409,
					Message = "UserName Already Exists"
				};

			AppUser newUser = new()
			{
				FirstName = registerDto.FirstName,
				LastName = registerDto.LastName,
				Email = registerDto.Email,
				UserName = registerDto.UserName,
				PhoneNumber = registerDto.PhoneNumber,
				Address = registerDto.Address,
				SecurityStamp = Guid.NewGuid().ToString()
			};

			var createUserResult = await userManager.CreateAsync(newUser, registerDto.Password);

			if (!createUserResult.Succeeded)
			{
				var errorString = "User Creation failed because: ";
				foreach (var error in createUserResult.Errors)
				{
					errorString += " # " + error.Description;
				}
				return new GeneralServiceResponseDto()
				{
					IsSucceed = false,
					StatusCode = 400,
					Message = errorString
				};
			}

			// Add a Default USER Role to all users
			await userManager.AddToRoleAsync(newUser, "Admin");
			await logService.SaveNewLog(newUser.UserName, "Registered to Portfolio Website");

			return new GeneralServiceResponseDto()
			{
				IsSucceed = true,
				StatusCode = 201,
				Message = "User Created Successfully"
			};
		}

		public async Task<GeneralServiceResponseDto> SeedRolesAsync()
		{
			bool isAdminRoleExists = await roleManager.RoleExistsAsync("Admin");
			if (isAdminRoleExists)
				return new GeneralServiceResponseDto()
				{
					IsSucceed = true,
					StatusCode = 200,
					Message = "Roles Seeding is Already Done"
				};
			await roleManager.CreateAsync(new IdentityRole("Admin"));
			return new GeneralServiceResponseDto()
			{
				IsSucceed = true,
				StatusCode = 201,
				Message = "Roles Seeding Done Successfully"
			};
		}

		//GenerateJWTTokenAsync
		private async Task<string> GenerateJWTTokenAsync(AppUser user)
		{
			var userRoles = await userManager.GetRolesAsync(user);

			var authClaims = new List<Claim>
			{
				new(ClaimTypes.Name, user.UserName),
				new(ClaimTypes.NameIdentifier, user.Id),
				new("FirstName", user.FirstName),
				new("LastName", user.LastName),
			};

			foreach (var userRole in userRoles)
			{
				authClaims.Add(new Claim(ClaimTypes.Role, userRole));
			}

			var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
			var signingCredentials = new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256);

			var tokenObject = new JwtSecurityToken(
				issuer: configuration["JWT:ValidIssuer"],
				audience: configuration["JWT:ValidAudience"],
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddHours(3),
				claims: authClaims,
				signingCredentials: signingCredentials
				);

			string token = new JwtSecurityTokenHandler().WriteToken(tokenObject);
			return token;
		}

		//GenerateUserInfoObject
		private static UserInfoResult GenerateUserInfoObject(AppUser user, IEnumerable<string> Roles)
		{
			// Instead of this, You can use Automapper packages. But i don't want it in this project
			return new UserInfoResult()
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserName = user.UserName,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				CreatedAt = user.CreatedAt,
				Roles = Roles
			};
		}
	}
}
