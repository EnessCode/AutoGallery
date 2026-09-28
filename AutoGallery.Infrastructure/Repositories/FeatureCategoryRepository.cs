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
	public class FeatureCategoryRepository : EfRepository<FeatureCategory>, IFeatureCategoryRepository
	{
		public FeatureCategoryRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<List<FeatureCategory>> GetAllWithFeaturesAsync()
		{
			return await _context.FeatureCategories
								 .Include(c => c.Features)
								 .ToListAsync();
		}
	}
}
