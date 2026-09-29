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

		public async Task<List<Car>> GetAllCarsWithImagesAsync()
		{
			return await _context.Cars
										.Include(c => c.CarImages)
										.OrderByDescending(c => c.Id)
										.ToListAsync();
		}

		public async Task<Car> GetCarWithDetailsByIdAsync(int id)
		{
			return await _context.Cars
							.Include(c => c.CarImages)
							.Include(c => c.Expertise)
							.Include(c => c.CarFeatures)
								.ThenInclude(cf => cf.Feature)
								.ThenInclude(f => f.FeatureCategory)
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

		public async Task<List<Car>> GetFilteredCarsAsync(string search = null, string gear = null, string fuel = null, string body = null, string color = null)
		{
			var query = _context.Cars.Include(c => c.CarImages).AsQueryable();

			if (!string.IsNullOrWhiteSpace(search))
			{
				query = query.Where(c => c.Brand.Contains(search) || c.Model.Contains(search));
			}

			if (!string.IsNullOrWhiteSpace(gear))
			{
				query = query.Where(c => c.GearType == gear);
			}

			if (!string.IsNullOrWhiteSpace(fuel))
			{
				query = query.Where(c => c.FuelType == fuel);
			}

			if (!string.IsNullOrWhiteSpace(body))
			{
				query = query.Where(c => c.BodyType == body);
			}

			if (!string.IsNullOrWhiteSpace(color))
			{
				query = query.Where(c => c.Color == color);
			}

			return await query.ToListAsync();
		}
	}
}
