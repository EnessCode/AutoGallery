using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class Feature : BaseEntity
	{
		public string Name { get; set; }
		public string Icon { get; set; }

		public int FeatureCategoryId { get; set; }
		public FeatureCategory FeatureCategory { get; set; }

		public List<CarFeature> CarFeatures { get; set; }
	}
}
