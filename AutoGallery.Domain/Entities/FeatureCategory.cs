using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class FeatureCategory : BaseEntity
	{
		public string Name { get; set; } 

		public List<Feature> Features { get; set; }
	}
}