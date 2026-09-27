using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class CarImage : BaseEntity
	{
		public string ImageUrl { get; set; }
		public bool IsMain { get; set; } 

		public int CarId { get; set; }
		public Car Car { get; set; }
	}
}
