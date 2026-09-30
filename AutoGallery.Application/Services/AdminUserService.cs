using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Services
{
	public class AdminUserService : IAdminUserService
	{
		private readonly IAdminUserRepository _adminUserRepository;

		public AdminUserService(IAdminUserRepository adminUserRepository)
		{
			_adminUserRepository = adminUserRepository;
		}

		public async Task<AdminUser> CheckCredentialsAsync(string username, string password)
		{
			var users = await _adminUserRepository.GetAllAsync();
			return users.FirstOrDefault(x => x.Username == username && x.Password == password);
		}
	}
}
