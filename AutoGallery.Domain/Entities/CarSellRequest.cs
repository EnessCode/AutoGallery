using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class CarSellRequest : BaseEntity
	{
		public string FullName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public int Kilometer { get; set; }
		public decimal PriceExpectation { get; set; }
		public string Message { get; set; }
		public string ImagesPath { get; set; }

		public bool IsReviewed { get; set; } = false; 
	}
}
