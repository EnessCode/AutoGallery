using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class ConsignmentRequest : BaseEntity
	{
		public string FullName { get; set; }
		public string Phone { get; set; }
		public string BrandAndModel { get; set; }
		public int Year { get; set; }
		public int Kilometer { get; set; }
		public string? Note { get; set; }
		public bool IsProcessed { get; set; } = false;
	}
}
