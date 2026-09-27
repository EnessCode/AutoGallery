using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Home
{
	public class HeroSliderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
