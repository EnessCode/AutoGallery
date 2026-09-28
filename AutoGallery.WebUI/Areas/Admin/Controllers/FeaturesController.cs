using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using AutoGallery.WebUI.Areas.Admin.Models;
using AutoGallery.WebUI.Areas.Admin.Models.Feature;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeaturesController : Controller
	{
		private readonly IFeatureCategoryService _categoryService;
		private readonly IFeatureService _featureService;

		public FeaturesController(IFeatureCategoryService categoryService, IFeatureService featureService)
		{
			_categoryService = categoryService;
			_featureService = featureService;
		}

		public async Task<IActionResult> Index()
		{
			var categories = await _categoryService.GetAllCategoriesAsync();
			return View(categories);
		}

		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View(new CreateCategoryViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateCategory(CreateCategoryViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _categoryService.CreateCategoryAsync(new FeatureCategory { Name = model.Name });
			TempData["SuccessMessage"] = "Kategori başarıyla eklendi.";
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> DeleteCategory(int id)
		{
			await _categoryService.DeleteCategoryAsync(id);
			TempData["SuccessMessage"] = "Kategori silindi.";
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> CreateFeature()
		{
			var categories = await _categoryService.GetAllCategoriesAsync();
			ViewBag.Categories = new SelectList(categories, "Id", "Name");
			return View(new CreateFeatureViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateFeature(CreateFeatureViewModel model)
		{
			if (!ModelState.IsValid)
			{
				var categories = await _categoryService.GetAllCategoriesAsync();
				ViewBag.Categories = new SelectList(categories, "Id", "Name");
				return View(model);
			}

			var feature = new Feature
			{
				Name = model.Name,
				Icon = model.Icon,
				FeatureCategoryId = model.FeatureCategoryId
			};

			await _featureService.CreateFeatureAsync(feature);
			TempData["SuccessMessage"] = "Donanım başarıyla eklendi.";
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> DeleteFeature(int id)
		{
			await _featureService.DeleteFeatureAsync(id);
			TempData["SuccessMessage"] = "Donanım silindi.";
			return RedirectToAction(nameof(Index));
		}
	}
}
