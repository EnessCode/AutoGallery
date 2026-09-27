using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents
{
	public class FeaturedCarsViewComponent : ViewComponent
	{
		private readonly ICarService _carService;

		public FeaturedCarsViewComponent(ICarService carService)
		{
			_carService = carService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var cars = await _carService.GetFeaturedCarsAsync();
			return View(cars);
		}
	}
}
