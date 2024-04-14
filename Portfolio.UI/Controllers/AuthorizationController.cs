using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Portfolio.UI.Services;
using Portfolio.UI.ViewModels;
using System.Text;

namespace Portfolio.UI.Controllers
{
	public class AuthorizationController(IHttpClientFactory httpClientFactory, IAuthService authService) : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel register)
		{
			if (ModelState.IsValid)
			{
				var registerResult = await authService.RegisterAsync(register);
				if (registerResult.IsSuccess)
				{
					// Kayıt başarılı, giriş sayfasına yönlendir
					return RedirectToAction("Login");
				}
				else
				{
					// API'den gelen hata mesajını ModelState'e ekle
					ModelState.AddModelError(string.Empty, registerResult.ErrorMessage);
				}
			}
			return View(register);
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel login)
		{
			 var loginResult = await authService.LoginAsync(login);
			if (loginResult.IsSuccess)
			{
				// Giriş başarılı ise ana sayfaya yönlendir
				return RedirectToAction("Experiences", "Experience");
			}
			else
			{
				// Giriş başarısız ise hata mesajını göster
				ModelState.AddModelError(string.Empty, loginResult.ErrorMessage);
				return View(login);
			}
		}

	}
}
