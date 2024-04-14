using System.ComponentModel.DataAnnotations;

namespace Portfolio.UI.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "UserName is required!")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Password is required!")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Confirm Password is required!")]
		[Compare("Password", ErrorMessage = "Passwords not match!")]
		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "First Name is required!")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required!")]
		public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required!")]
		[DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required!")]
		[DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
		public string Address { get; set; }
	}
}
