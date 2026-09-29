using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Home
{
	public class HeroSliderViewComponent : ViewComponent
	{
		private readonly ISliderService _sliderService;

		public HeroSliderViewComponent(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var sliders = await _sliderService.GetActiveSlidersAsync();
			return View(sliders);
		}
	}
}
