using AutoGallery.Application.Interfaces.Services;
using AutoGallery.WebUI.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AutoGallery.WebUI.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAdminUserService _adminUserService;

		public AccountController(IAdminUserService adminUserService)
		{
			_adminUserService = adminUserService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			if (User.Identity.IsAuthenticated)
			{
				return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
			}
			return View(new LoginViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var adminUser = await _adminUserService.CheckCredentialsAsync(model.Username, model.Password);

			if (adminUser != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, adminUser.FullName),
					new Claim(ClaimTypes.Role, "Admin")
				};

				var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var principal = new ClaimsPrincipal(identity);

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

				return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
			}

			ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index", "Home");
		}
	}
}
