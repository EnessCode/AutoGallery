using System.ComponentModel.DataAnnotations;

namespace AutoGallery.WebUI.Areas.Admin.Models.Feature
{
	public class CreateFeatureViewModel
	{
		[Required(ErrorMessage = "Donanım adı zorunludur.")]
		public string Name { get; set; }

		public string? Icon { get; set; } 

		[Required(ErrorMessage = "Lütfen bir kategori seçin.")]
		public int FeatureCategoryId { get; set; }
	}
}
