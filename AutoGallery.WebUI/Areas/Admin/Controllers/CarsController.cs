using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using AutoGallery.WebUI.Areas.Admin.Helpers;
using AutoGallery.WebUI.Areas.Admin.Models.Car;
using AutoGallery.WebUI.Areas.Admin.Services;
using AutoGallery.WebUI.Areas.Admin.Services.Car;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class CarsController : Controller
	{
		private readonly ICarService _carService;
		private readonly ICarFeatureService _carFeatureService;
		private readonly IImageUploadService _imageUploadService;
		private readonly ICarViewService _carViewService;

		public CarsController(
			ICarService carService,
			ICarFeatureService carFeatureService,
			IImageUploadService imageUploadService,
			ICarViewService carViewService)
		{
			_carService = carService;
			_carFeatureService = carFeatureService;
			_imageUploadService = imageUploadService;
			_carViewService = carViewService;
		}

		public async Task<IActionResult> Index(int page = 1)
		{
			int pageSize = 10; 

			var allCars = await _carService.GetAllCarsAsync();

			int totalItems = allCars.Count;
			int totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

			var paginatedCars = allCars
				.OrderByDescending(x => x.Id)
				.Skip((page - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			ViewBag.CurrentPage = page;
			ViewBag.TotalPages = totalPages;

			return View(paginatedCars);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var model = await _carViewService.FillFeatureCategoriesAsync(new CreateCarViewModel());
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[RequestSizeLimit(200 * 1024 * 1024)]
		[RequestFormLimits(MultipartBodyLengthLimit = 200 * 1024 * 1024)]
		public async Task<IActionResult> Create(CreateCarViewModel vm)
		{
			if (!ModelState.IsValid)
				return View(await _carViewService.FillFeatureCategoriesAsync(vm));

			var images = await _imageUploadService.SaveCarImagesAsync(vm.UploadedImages, vm.MainImageIndex);
			var car = vm.ToEntity(images);

			await _carService.CreateCarAsync(car);
			await _carFeatureService.AssignFeaturesToCarAsync(car.Id, vm.SelectedFeatureIds.Distinct().ToList());

			TempData["Success"] = "Araç başarıyla eklendi.";
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var car = await _carService.GetCarDetailsAsync(id);
			if (car == null) return NotFound();

			var vm = car.ToEditViewModel();
			return View(await _carViewService.FillFeatureCategoriesAsync(vm));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[RequestSizeLimit(200 * 1024 * 1024)]
		[RequestFormLimits(MultipartBodyLengthLimit = 200 * 1024 * 1024)]
		public async Task<IActionResult> Edit(EditCarViewModel vm)
		{
			var car = await _carService.GetCarDetailsAsync(vm.Id);
			if (car == null) return NotFound();

			if (!ModelState.IsValid)
			{
				vm.ExistingImages = car.CarImages?.ToList() ?? new List<CarImage>();
				return View(await _carViewService.FillFeatureCategoriesAsync(vm));
			}

			car.UpdateFromEditModel(vm);
			car.Expertise ??= new CarExpertise();
			car.Expertise.MapExpertise(vm.Expertise);

			if (vm.UploadedImages != null && vm.UploadedImages.Count > 0)
			{
				var newImages = await _imageUploadService.SaveCarImagesAsync(vm.UploadedImages, vm.MainImageIndex);
				if (newImages.Any(x => x.IsMain))
				{
					foreach (var existingImg in car.CarImages) existingImg.IsMain = false;
				}
				foreach (var img in newImages) car.CarImages.Add(img);
			}

			await _carService.UpdateCarAsync(car);
			await _carFeatureService.AssignFeaturesToCarAsync(car.Id, vm.SelectedFeatureIds.Distinct().ToList());

			TempData["Success"] = "Araç başarıyla güncellendi.";
			return RedirectToAction(nameof(Index));
		}
	}
}
