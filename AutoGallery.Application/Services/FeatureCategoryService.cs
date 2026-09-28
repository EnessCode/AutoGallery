using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Services
{
	public class FeatureCategoryService : IFeatureCategoryService
	{
		private readonly IFeatureCategoryRepository _repository;
		
		public FeatureCategoryService(IFeatureCategoryRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<FeatureCategory>> GetAllCategoriesAsync()
		{
			return await _repository.GetAllWithFeaturesAsync();
		}

		public async Task<FeatureCategory> GetCategoryByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task CreateCategoryAsync(FeatureCategory category)
		{
			await _repository.AddAsync(category);
		}

		public async Task UpdateCategoryAsync(FeatureCategory category)
		{
			_repository.Update(category);
		}

		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _repository.GetByIdAsync(id);

			if (category != null)
			{
				_repository.Delete(category);
			}
		}
	}
}
