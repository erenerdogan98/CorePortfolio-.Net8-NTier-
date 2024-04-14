using Portfolio.UI.ViewModels;

namespace Portfolio.UI.Services
{
	public interface IAuthService
	{
		Task<LoginResult> LoginAsync(LoginViewModel loginViewModel);
		Task<RegisterResult> RegisterAsync(RegisterViewModel registerViewModel);
	}
}
