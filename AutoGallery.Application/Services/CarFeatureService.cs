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
	public class CarFeatureService : ICarFeatureService
	{
		private readonly IRepository<CarFeature> _repository;

		public CarFeatureService(IRepository<CarFeature> repository)
		{
			_repository = repository;
		}

		public async Task<List<CarFeature>> GetCarFeaturesByCarIdAsync(int carId)
		{
			return await _repository.GetByFilterAsync(cf => cf.CarId == carId);
		}

		public async Task AssignFeaturesToCarAsync(int carId, List<int> featureIds)
		{
			var existingFeatures = await _repository.GetByFilterAsync(cf => cf.CarId == carId);

			foreach (var feature in existingFeatures)
			{
				_repository.Delete(feature);
			}

			if (featureIds != null && featureIds.Any())
			{
				foreach (var featureId in featureIds)
				{
					await _repository.AddAsync(new CarFeature
					{
						CarId = carId,
						FeatureId = featureId
					});
				}
			}
		}
	}
}
