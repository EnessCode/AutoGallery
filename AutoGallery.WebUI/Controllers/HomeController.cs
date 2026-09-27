using AutoGallery.Application.Interfaces.Services;
using AutoGallery.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoGallery.WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICarService _carService;

		public HomeController(ICarService carService)
		{
			_carService = carService;
		}

		public async Task<IActionResult> Index()
		{
			var featuredCars = await _carService.GetFeaturedCarsAsync();
			return View(featuredCars);
		}

		public IActionResult About()
		{
			return View();
		}
	}
}
