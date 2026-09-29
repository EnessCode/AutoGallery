using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Car
{
	public class CarDetailExpertiseViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(CarExpertise expertise)
		{
			return View(expertise);
		}
	}
}
