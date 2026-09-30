using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Controllers
{
	public class CarController : Controller
	{
		private readonly ICarService _carService;

		public CarController(ICarService carService)
		{
			_carService = carService;
		}
		public async Task<IActionResult> Index(string search, string gear, string fuel, string body, string color)
		{
			var cars = await _carService.GetAllCarsAsync(search, gear, fuel, body, color);
			var activeCars = cars?.Where(c => !c.IsSold).ToList();

			return View(activeCars);
		}

		public async Task<IActionResult> Detail(int id)
		{
			var car = await _carService.GetCarDetailsAsync(id);

			if (car == null)
			{
				return NotFound();
			}

			return View(car);
		}
	}
}
