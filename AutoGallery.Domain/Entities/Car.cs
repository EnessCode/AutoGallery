using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class Car : BaseEntity
	{
		public string Title { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public decimal Price { get; set; }
		public int Kilometer { get; set; }
		public string FuelType { get; set; }
		public string GearType { get; set; }
		public string Color { get; set; }
		public string BodyType { get; set; }
		public string EngineCapacity { get; set; }
		public string HorsePower { get; set; }
		public string Description { get; set; }

		public bool IsFeatured { get; set; }
		public bool IsSold { get; set; }

		public List<CarImage> CarImages { get; set; }
		public CarExpertise Expertise { get; set; }
		public List<CarFeature> CarFeatures { get; set; }
	}
}
