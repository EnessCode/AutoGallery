using AutoGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Infrastructure.Contexts
{
	public static class DbInitializer
	{
		public static void Seed(ApplicationDbContext context)
		{
			context.Database.Migrate();
			
			if (!context.AdminUsers.Any())
			{
				context.AdminUsers.Add(new AdminUser
				{
					Username = "admin",
					Password = "gallery2026", 
					FullName = "Admin Admin",
					CreatedAt = DateTime.UtcNow
				});

				context.SaveChanges();
			}
		}
	}
}
