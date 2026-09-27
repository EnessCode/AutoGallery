using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents
{
	public class HeroSliderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
