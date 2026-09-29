using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Home
{
	public class ExpertiseViewComponent : ViewComponent
	{
		private readonly IExpertiseInfoService _expertiseInfoService;

		public ExpertiseViewComponent(IExpertiseInfoService expertiseInfoService)
		{
			_expertiseInfoService = expertiseInfoService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var value = await _expertiseInfoService.GetExpertiseInfoAsync();
			return View(value);
		}
	}
}
