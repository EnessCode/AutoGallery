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
	public class FeatureService : IFeatureService
	{
		private readonly IRepository<Feature> _repository;

		public FeatureService(IRepository<Feature> repository)
		{
			_repository = repository;
		}

		public async Task<List<Feature>> GetAllFeaturesAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task<Feature> GetFeatureByIdAsync(int id)
		{
			return await _repository.GetByIdAsync(id);
		}

		public async Task<List<Feature>> GetFeaturesByCategoryIdAsync(int categoryId)
		{
			return await _repository.GetByFilterAsync(f => f.FeatureCategoryId == categoryId);
		}

		public async Task CreateFeatureAsync(Feature feature)
		{
			await _repository.AddAsync(feature);
		}

		public async Task UpdateFeatureAsync(Feature feature)
		{
			_repository.Update(feature);
		}

		public async Task DeleteFeatureAsync(int id)
		{
			var feature = await _repository.GetByIdAsync(id);

			if (feature != null)
			{
				_repository.Delete(feature);
			}
		}
	}
}
