using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Car
{
	public class CarDetailDescriptionViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(string description)
		{
			return View("Default", description);
		}
	}
}
