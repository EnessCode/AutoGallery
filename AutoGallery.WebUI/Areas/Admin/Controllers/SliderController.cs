using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
		private readonly ISliderService _sliderService;

		public SliderController(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _sliderService.GetAllSlidersAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Slider slider)
		{
			await _sliderService.CreateSliderAsync(slider);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var value = await _sliderService.GetSliderByIdAsync(id);
			if (value == null)
			{
				return NotFound();
			}
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Slider slider)
		{
			await _sliderService.UpdateSliderAsync(slider);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _sliderService.DeleteSliderAsync(id);
			return RedirectToAction("Index");
		}
	}
}
