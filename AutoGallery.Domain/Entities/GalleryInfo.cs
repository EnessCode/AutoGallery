using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class GalleryInfo : BaseEntity
	{
		public string Title { get; set; }          
		public string Address { get; set; }     
		public string Phone1 { get; set; }        
		public string? Phone2 { get; set; }          
		public string Email { get; set; }           
		public string WorkingHoursWeekdays { get; set; } 
		public string WorkingHoursWeekend { get; set; }
		public string? GoogleMapUrl { get; set; }
		public string? InstagramUrl { get; set; }
		public string? LinkedinUrl { get; set; }
		public string? YoutubeUrl { get; set; }
	}
}
