using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Car
{
	public class CarListViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(List<AutoGallery.Domain.Entities.Car> cars)
		{
			return View(cars);
		}
	}
}
