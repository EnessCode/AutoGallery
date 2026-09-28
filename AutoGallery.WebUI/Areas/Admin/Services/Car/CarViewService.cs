using AutoGallery.Application.Interfaces.Services;
using AutoGallery.WebUI.Areas.Admin.Models.Car;

namespace AutoGallery.WebUI.Areas.Admin.Services.Car
{
	public class CarViewService : ICarViewService
	{
		private readonly IFeatureCategoryService _featureCategoryService;
		private readonly IFeatureService _featureService;

		public CarViewService(IFeatureCategoryService featureCategoryService, IFeatureService featureService)
		{
			_featureCategoryService = featureCategoryService;
			_featureService = featureService;
		}

		public async Task<T> FillFeatureCategoriesAsync<T>(T model) where T : ICarViewModel
		{
			var categories = await _featureCategoryService.GetAllCategoriesAsync();
			var features = await _featureService.GetAllFeaturesAsync();

			model.FeatureCategories = categories
				.OrderBy(c => c.Id)
				.Select(c => new FeatureCategoryItem
				{
					Id = c.Id,
					Name = c.Name,
					Features = features
						.Where(f => f.FeatureCategoryId == c.Id)
						.OrderBy(f => f.Name)
						.Select(f => new FeatureItem { Id = f.Id, Name = f.Name, Icon = f.Icon })
						.ToList()
				})
				.Where(c => c.Features.Count > 0)
				.ToList();

			return model;
		}
	}
}
