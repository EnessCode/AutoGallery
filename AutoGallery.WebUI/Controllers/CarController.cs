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
		public async Task<IActionResult> Index(string search, string gear, string fuel, string body, string color, int page = 1)
		{
			var cars = await _carService.GetAllCarsAsync(search, gear, fuel, body, color);

			var activeCars = cars?.Where(c => !c.IsSold).ToList() ?? new List<Domain.Entities.Car>();

			int pageSize = 9;
			int totalItems = activeCars.Count;
			int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

			var paginatedCars = activeCars
				.OrderByDescending(x => x.Id)
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			ViewBag.CurrentPage = page;
			ViewBag.TotalPages = totalPages;

			ViewBag.SearchTerm = search;
			ViewBag.Gear = gear;
			ViewBag.Fuel = fuel;
			ViewBag.Body = body;
			ViewBag.Color = color;

			return View(paginatedCars);
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
