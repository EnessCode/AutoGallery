using AutoGallery.Application.Interfaces.Services;
using AutoGallery.WebUI.Areas.Admin.Models.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
		private readonly ICarService _carService;
		private readonly IConsignmentRequestService _consignmentService;

		public DashboardController(ICarService carService, IConsignmentRequestService consignmentService)
		{
			_carService = carService;
			_consignmentService = consignmentService;
		}

		public async Task<IActionResult> Index()
		{
			var cars = await _carService.GetAllCarsAsync();
			var featuredCars = await _carService.GetFeaturedCarsAsync();

			var consignments = await _consignmentService.GetAllRequestsAsync();

			var model = new DashboardViewModel
			{
				TotalCars = cars.Count(x => !x.IsSold),
				SoldCars = cars.Count(x => x.IsSold),
				FeaturedCarsCount = featuredCars.Count,
				PendingConsignments = consignments.Count(x => !x.IsProcessed),

				RecentConsignments = consignments.OrderByDescending(x => x.Id).Take(5).ToList(),
				RecentCars = cars.OrderByDescending(x => x.Id).Take(5).ToList()
			};

			return View(model);
		}
	}
}
