using System.ComponentModel.DataAnnotations;

namespace AutoGallery.WebUI.Models.Account
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz.")]
		[Display(Name = "Kullanıcı Adı")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
		[DataType(DataType.Password)]
		[Display(Name = "Şifre")]
		public string Password { get; set; }
	}
}
