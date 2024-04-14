using Portfolio.API.Core.Dtos.Auth;
using Portfolio.API.Core.Dtos.General;

namespace Portfolio.API.Core.Interfaces
{
	public interface IAuthService
	{
		Task<GeneralServiceResponseDto> SeedRolesAsync();
		Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto);
		Task<LoginServiceResponseDto?> LoginAsync(LoginDto loginDto);
		Task<LoginServiceResponseDto?> TokenAsync(TokenDto tokenDto);
		Task<IEnumerable<UserInfoResult>> GetUsersListAsync();
		Task<UserInfoResult?> GetUserDetailsByUserNameAsync(string userName);
		Task<IEnumerable<string>> GetUsernamesListAsync();
	}
}
