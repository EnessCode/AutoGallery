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
	public class SliderRepository : EfRepository<Slider>, ISliderRepository
	{
		public SliderRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<List<Slider>> GetActiveSlidersAsync()
		{
			return await _context.Sliders
								 .Where(s => s.IsActive)
								 .OrderBy(s => s.Order)
								 .ToListAsync();
		}
	}
}
