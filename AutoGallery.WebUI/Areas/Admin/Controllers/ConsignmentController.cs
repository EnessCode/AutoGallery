using AutoGallery.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ConsignmentController : Controller
	{
		private readonly IConsignmentRequestService _service;

		public ConsignmentController(IConsignmentRequestService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
		{
			var values = await _service.GetAllRequestsAsync();
			return View(values);
		}

		public async Task<IActionResult> ToggleStatus(int id)
		{
			await _service.ToggleStatusAsync(id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteRequestAsync(id);
			return RedirectToAction("Index");
		}
	}
}
