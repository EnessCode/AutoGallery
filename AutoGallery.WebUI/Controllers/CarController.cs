using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGallery.WebUI.Controllers
{
	public class CarController : Controller
	{
		private readonly ICarService _carService;

		public CarController(ICarService carService)
		{
			_carService = carService;
		}

		public async Task<IActionResult> Index(string search, string gear, string fuel, string body, string sort, int page = 1)
		{
			var cars = await _carService.GetAllCarsAsync(search, gear, fuel, body, null);

			var activeCars = cars?.Where(c => !c.IsSold).ToList() ?? new List<Domain.Entities.Car>();

			IEnumerable<Domain.Entities.Car> sortedCars = sort switch
			{
				"price_asc" => activeCars.OrderBy(x => x.Price),
				"price_desc" => activeCars.OrderByDescending(x => x.Price),
				"year_desc" => activeCars.OrderByDescending(x => x.Year),
				"year_asc" => activeCars.OrderBy(x => x.Year),
				"km_asc" => activeCars.OrderBy(x => x.Kilometer),
				_ => activeCars.OrderByDescending(x => x.Id)
			};

			int pageSize = 9;
			int totalItems = sortedCars.Count();
			int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

			var paginatedCars = sortedCars
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			ViewBag.CurrentPage = page;
			ViewBag.TotalPages = totalPages;

			ViewBag.SearchTerm = search;
			ViewBag.Gear = gear;
			ViewBag.Fuel = fuel;
			ViewBag.Body = body;
			ViewBag.Sort = sort;

			return View(paginatedCars);
		}

		public async Task<IActionResult> Detail(int id)
		{
			var car = await _carService.GetCarDetailsAsync(id);
			if (car == null) return NotFound();
			return View(car);
		}
	}
}
