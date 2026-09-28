using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Services
{
	public interface IFeatureService
	{
		Task<List<Feature>> GetAllFeaturesAsync();
		Task<Feature> GetFeatureByIdAsync(int id);
		Task<List<Feature>> GetFeaturesByCategoryIdAsync(int categoryId);
		Task CreateFeatureAsync(Feature feature);
		Task UpdateFeatureAsync(Feature feature);
		Task DeleteFeatureAsync(int id);
	}
}
