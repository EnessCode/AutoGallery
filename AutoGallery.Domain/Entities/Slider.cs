using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class Slider : BaseEntity
	{
		public string Title { get; set; }
		public string? SubTitle { get; set; }    
		public string ImageUrl { get; set; }
		public string? BadgeText { get; set; }    
		public string? ButtonText { get; set; }  
		public string? ButtonUrl { get; set; }   
		public int Order { get; set; }
		public bool IsActive { get; set; }
	}
}
