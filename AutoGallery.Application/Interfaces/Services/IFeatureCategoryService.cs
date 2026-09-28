using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Services
{
	public interface IFeatureCategoryService
	{
		Task<List<FeatureCategory>> GetAllCategoriesAsync();
		Task<FeatureCategory> GetCategoryByIdAsync(int id);
		Task CreateCategoryAsync(FeatureCategory category);
		Task UpdateCategoryAsync(FeatureCategory category);
		Task DeleteCategoryAsync(int id);
	}
}
