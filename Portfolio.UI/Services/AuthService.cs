using Newtonsoft.Json;
using Portfolio.UI.ViewModels;
using System.Text;

namespace Portfolio.UI.Services
{
	public class AuthService(IHttpClientFactory httpClientFactory) : IAuthService
	{
		private readonly IHttpClientFactory _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
		public async Task<LoginResult> LoginAsync(LoginViewModel loginViewModel)
		{
			var client = _httpClientFactory.CreateClient();

			var jsonData = JsonConvert.SerializeObject(loginViewModel);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:7253/api/Auth/login", stringContent);
			var content = await response.Content.ReadAsStringAsync();

			if (response.IsSuccessStatusCode)
			{
				// API'den başarılı bir şekilde giriş yapıldıysa, kullanıcı bilgilerini döndür
				var loginServiceResponse = JsonConvert.DeserializeObject<LoginServiceResponse>(content);
				return new LoginResult { IsSuccess = true, LoginServiceResponse = loginServiceResponse };
			}
			else
			{
				// API'den hata döndüyse, hatayı döndür
				return new LoginResult { IsSuccess = false, ErrorMessage = content };
			}
		}

		public async Task<RegisterResult> RegisterAsync(RegisterViewModel registerViewModel)
		{
			var client = _httpClientFactory.CreateClient();

			var jsonData = JsonConvert.SerializeObject(registerViewModel);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

			var response = await client.PostAsync("https://localhost:7253/api/Auth/register", stringContent);
			var content = await response.Content.ReadAsStringAsync();

			if (response.IsSuccessStatusCode)
			{
				return new RegisterResult { IsSuccess = true };
			}
			else
			{
				// API'den gelen hata mesajını içeren nesneyi döndür
				return new RegisterResult { IsSuccess = false, ErrorMessage = content };
			}
		}
	}
}
