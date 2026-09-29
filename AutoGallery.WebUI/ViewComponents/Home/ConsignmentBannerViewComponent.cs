using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Home
{
	public class ConsignmentBannerViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
