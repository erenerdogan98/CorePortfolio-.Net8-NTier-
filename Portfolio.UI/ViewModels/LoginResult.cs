namespace Portfolio.UI.ViewModels
{
	public class LoginResult
	{
		public bool IsSuccess { get; set; }
		public LoginServiceResponse LoginServiceResponse { get; set; } // Başarılı giriş durumunda API'den dönen yanıt
		public string ErrorMessage { get; set; } // Hata durumunda API'den dönen hata mesajı
	}
}

