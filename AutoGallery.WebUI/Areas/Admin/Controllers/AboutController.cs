using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AboutController : Controller
	{
		private readonly IAboutInfoService _aboutInfoService;

		public AboutController(IAboutInfoService aboutInfoService)
		{
			_aboutInfoService = aboutInfoService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var aboutInfo = await _aboutInfoService.GetAboutInfoAsync();
			return View(aboutInfo);
		}

		[HttpPost]
		public async Task<IActionResult> Index(AboutInfo model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _aboutInfoService.UpdateAboutInfoAsync(model);
			TempData["SuccessMessage"] = "Hakkımızda bilgileri başarıyla güncellendi.";
			return RedirectToAction(nameof(Index));
		}
	}
}
