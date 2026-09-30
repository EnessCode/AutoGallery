using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Domain.Entities;
using AutoGallery.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Infrastructure.Repositories
{
	public class AdminUserRepository : EfRepository<AdminUser>, IAdminUserRepository
	{
		public AdminUserRepository(ApplicationDbContext context) : base(context)
		{
		}
	}
}
