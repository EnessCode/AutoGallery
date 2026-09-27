using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using AutoGallery.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ContactFormViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var contactMessage = new ContactMessage
			{
				Name = model.Name,
				Email = model.Email,
				Subject = model.Subject,
				Message = model.Message
			};

			await _contactService.SendMessageAsync(contactMessage);

			TempData["SuccessMessage"] = "Mesajınız başarıyla iletildi. En kısa sürede sizinle iletişime geçilecektir.";
			return RedirectToAction("Index");
		}
	}
}
