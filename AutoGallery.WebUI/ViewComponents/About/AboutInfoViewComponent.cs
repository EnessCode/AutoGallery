using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents
{
	public class AboutInfoViewComponent : ViewComponent
	{
		private readonly IAboutInfoService _aboutInfoService;

		public AboutInfoViewComponent(IAboutInfoService aboutInfoService)
		{
			_aboutInfoService = aboutInfoService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _aboutInfoService.GetAboutInfoAsync();
			return View(values);
		}
	}
}
