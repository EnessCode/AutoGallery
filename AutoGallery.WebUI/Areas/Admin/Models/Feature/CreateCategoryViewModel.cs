using System.ComponentModel.DataAnnotations;

namespace AutoGallery.WebUI.Areas.Admin.Models.Feature
{
	public class CreateCategoryViewModel
	{
		[Required(ErrorMessage = "Kategori adı zorunludur.")]
		public string Name { get; set; }
	}
}
