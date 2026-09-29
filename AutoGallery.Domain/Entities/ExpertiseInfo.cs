using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class ExpertiseInfo : BaseEntity
	{
		public string SubTitle { get; set; }        
		public string Title { get; set; }          
		public string Description { get; set; }     

		public string Stat1Value { get; set; }     
		public string Stat1Label { get; set; }   

		public string Stat2Value { get; set; }     
		public string Stat2Label { get; set; }     

		public string Stat3Value { get; set; }     
		public string Stat3Label { get; set; }     
	}
}
