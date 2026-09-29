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
	public class ExpertiseInfoRepository : EfRepository<ExpertiseInfo>, IExpertiseInfoRepository
	{
		public ExpertiseInfoRepository(ApplicationDbContext context) : base(context)
		{
		}

		public async Task<ExpertiseInfo> GetExpertiseInfoAsync()
		{
			return await _context.ExpertiseInfos.FirstOrDefaultAsync();
		}
	}
}
