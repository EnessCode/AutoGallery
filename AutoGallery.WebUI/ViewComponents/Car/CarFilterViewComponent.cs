using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Car
{
	public class CarFilterViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
