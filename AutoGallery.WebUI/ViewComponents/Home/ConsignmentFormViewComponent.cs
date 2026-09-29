using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Home
{
	public class ConsignmentFormViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(new ConsignmentRequest());
		}
	}
}
