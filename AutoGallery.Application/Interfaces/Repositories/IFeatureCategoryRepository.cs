using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Repositories
{
	public interface IFeatureCategoryRepository : IRepository<FeatureCategory>
	{
		Task<List<FeatureCategory>> GetAllWithFeaturesAsync();
	}
}
