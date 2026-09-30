using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class GalleryInfoController : Controller
	{
		private readonly IGalleryInfoService _galleryInfoService;

		public GalleryInfoController(IGalleryInfoService galleryInfoService)
		{
			_galleryInfoService = galleryInfoService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var galleryInfo = await _galleryInfoService.GetGalleryInfoAsync();
			return View(galleryInfo);
		}

		[HttpPost]
		public async Task<IActionResult> Index(GalleryInfo model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _galleryInfoService.UpdateGalleryInfoAsync(model);
			TempData["SuccessMessage"] = "Galeri bilgileri başarıyla güncellendi.";
			return RedirectToAction(nameof(Index));
		}
	}
}