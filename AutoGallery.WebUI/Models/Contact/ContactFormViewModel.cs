using System.ComponentModel.DataAnnotations;

namespace AutoGallery.WebUI.Models
{
	public class ContactFormViewModel
	{
		[Required(ErrorMessage = "Ad Soyad alanı zorunludur.")]
		public string Name { get; set; }

		[Required(ErrorMessage = "E-Posta adresi zorunludur.")]
		[EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Konu alanı zorunludur.")]
		public string Subject { get; set; }

		[Required(ErrorMessage = "Mesaj alanı zorunludur.")]
		public string Message { get; set; }
	}
}