using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Contact
{
	public class GalleryInfoViewComponent : ViewComponent
	{
		private readonly IGalleryInfoService _galleryInfoService;

		public GalleryInfoViewComponent(IGalleryInfoService galleryInfoService)
		{
			_galleryInfoService = galleryInfoService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var values = await _galleryInfoService.GetGalleryInfoAsync();
			return View(values);
		}
	}
}
