using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Car
{
	public class CarDetailGalleryViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(Domain.Entities.Car car)
		{
			return View(car);
		}
	}
}
