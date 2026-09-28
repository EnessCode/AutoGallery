using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class AboutInfo : BaseEntity
	{
		public string TopTitle { get; set; } 
		public string Description1 { get; set; } 
		public string Description2 { get; set; } 

		public string Stat1Value { get; set; } 
		public string Stat1Text { get; set; } 
		public string Stat1Icon { get; set; }  

 		public string Stat2Value { get; set; } 
		public string Stat2Text { get; set; } 
		public string Stat2Icon { get; set; }  

 		public string Stat3Value { get; set; } 
		public string Stat3Text { get; set; } 
		public string Stat3Icon { get; set; }   

 		public string Stat4Value { get; set; } 
		public string Stat4Text { get; set; } 
		public string Stat4Icon { get; set; }  
	}
}
