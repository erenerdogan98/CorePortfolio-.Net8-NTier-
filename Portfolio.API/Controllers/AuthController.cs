using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Core.Dtos.Auth;
using Portfolio.API.Core.Interfaces;

namespace Portfolio.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(IAuthService authService) : ControllerBase
	{
		// Route -> Seed Roles to DB
		[HttpPost("seed-roles")]
		public async Task<IActionResult> SeedRoles()
		{
			var seedResult = await authService.SeedRolesAsync();
			return StatusCode(seedResult.StatusCode, seedResult.Message);
		}

		// Route -> Register
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
		{
			var registerResult = await authService.RegisterAsync(registerDto);
			return StatusCode(registerResult.StatusCode, registerResult.Message);
		}

		// Route -> Login
		[HttpPost("login")]
		public async Task<ActionResult<LoginServiceResponseDto>> Login([FromBody] LoginDto loginDto)
		{
			var loginResult = await authService.LoginAsync(loginDto);

			if (loginResult is null)
			{
				return Unauthorized("Your credentials are invalid. Please contact to an Admin");
			}

			return Ok(loginResult);
		}

		// Route -> getting data of a user from it's JWT
		[HttpPost("token")]
		public async Task<ActionResult<LoginServiceResponseDto>> Me([FromBody] TokenDto token)
		{
			try
			{
				var me = await authService.TokenAsync(token);
				if (me is not null)
				{
					return Ok(me);
				}
				else
				{
					return Unauthorized("Invalid Token");
				}
			}
			catch (Exception)
			{
				return Unauthorized("Invalid Token");
			}
		}

		// Route -> List of all users with details
		[HttpGet("users")]
		public async Task<ActionResult<IEnumerable<UserInfoResult>>> GetUsersList()
		{
			var usersList = await authService.GetUsersListAsync();

			return Ok(usersList);
		}

		// Route -> Get a User by UserName
		[HttpGet("users/{userName}")]
		public async Task<ActionResult<UserInfoResult>> GetUserDetailsByUserName([FromRoute] string userName)
		{
			var user = await authService.GetUserDetailsByUserNameAsync(userName);
			if (user is not null)
			{
				return Ok(user);
			}
			else
			{
				return NotFound("UserName not found");
			}
		}

		// Route -> Get List of all usernames for send message
		[HttpGet("usernames")]
		public async Task<ActionResult<IEnumerable<string>>> GetUserNamesList()
		{
			var usernames = await authService.GetUsernamesListAsync();

			return Ok(usernames);
		}
	}
}
