using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Application.Services;
using AutoGallery.Domain.Entities;
using AutoGallery.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoGallery.WebUI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICarService _carService;
		private readonly IConsignmentRequestService _consignmentRequestService;

		public HomeController(ICarService carService, IConsignmentRequestService consignmentRequestService)
		{
			_carService = carService;
			_consignmentRequestService = consignmentRequestService;
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

		[HttpPost]
		public async Task<IActionResult> SubmitConsignment(ConsignmentRequest request)
		{
			await _consignmentRequestService.CreateRequestAsync(request);
			TempData["ConsignmentSuccess"] = "Araç talep formunuz baþarýyla alýnmýþtýr. Uzman ekibimiz en kýsa sürede sizinle iletiþime geçecektir.";
			return RedirectToAction("Index", "Home", null, "konsinye");
		}
	}
}
