using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoGallery.WebUI.ViewComponents.Car
{
	public class CarDetailFeaturesViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(IEnumerable<CarFeature> features)
		{
			var groupedFeatures = new Dictionary<string, List<CarFeature>>();

			if (features != null && features.Any())
			{
				groupedFeatures = features
					.Where(cf => cf.Feature != null && cf.Feature.FeatureCategory != null)
					.GroupBy(cf => cf.Feature.FeatureCategory.Name)
					.ToDictionary(g => g.Key, g => g.ToList());
			}

			return View(groupedFeatures);
		}
	}
}
