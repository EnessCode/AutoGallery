using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ExpertiseInfoController : Controller
	{
		private readonly IExpertiseInfoService _expertiseInfoService;

		public ExpertiseInfoController(IExpertiseInfoService expertiseInfoService)
		{
			_expertiseInfoService = expertiseInfoService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var value = await _expertiseInfoService.GetExpertiseInfoAsync();

			if (value == null)
			{
				value = new ExpertiseInfo();
			}

			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> Index(ExpertiseInfo expertiseInfo)
		{
			if (expertiseInfo.Id == 0)
			{
				await _expertiseInfoService.UpdateExpertiseInfoAsync(expertiseInfo); 
			}
			else
			{
				await _expertiseInfoService.UpdateExpertiseInfoAsync(expertiseInfo);
			}

			TempData["SuccessMessage"] = "Ekspertiz bilgileri başarıyla güncellendi.";
			return RedirectToAction("Index");
		}
	}
}
