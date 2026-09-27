using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Domain.Entities;
using AutoGallery.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Infrastructure.Repositories
{
	public class CarRepository : EfRepository<Car>, ICarRepository
	{
		public CarRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<Car> GetCarWithDetailsByIdAsync(int id)
		{
			return await _context.Cars
							.Include(c => c.CarImages)
							.Include(c => c.Expertise)
							.Include(c => c.CarFeatures)
								.ThenInclude(cf => cf.Feature)
							.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<List<Car>> GetFeaturedCarsAsync()
		{
			return await _context.Cars
							.Include(c => c.CarImages)
							.Where(c => c.IsFeatured && !c.IsSold)
							.OrderByDescending(c => c.CreatedAt)
							.Take(6)
							.ToListAsync();
		}
	}
}
