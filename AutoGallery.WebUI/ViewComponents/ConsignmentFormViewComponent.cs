using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents
{
	public class ConsignmentFormViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
