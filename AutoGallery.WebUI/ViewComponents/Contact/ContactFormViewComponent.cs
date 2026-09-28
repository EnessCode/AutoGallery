using AutoGallery.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Contact
{
	public class ContactFormViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var model = new ContactFormViewModel();
			return View(model);
		}
	}
}
