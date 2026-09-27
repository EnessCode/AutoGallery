using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		public async Task<IActionResult> Index()
		{
			var messages = await _contactService.GetAllMessagesAsync();
			return View(messages);
		}

		public async Task<IActionResult> Details(int id)
		{
			var message = await _contactService.GetMessageByIdAsync(id);
			if (message == null)
			{
				return NotFound();
			}

			if (!message.IsRead)
			{
				await _contactService.MarkAsReadAsync(id);
			}

			return View(message);
		}

		public async Task<IActionResult> MarkAsRead(int id)
		{
			await _contactService.MarkAsReadAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
