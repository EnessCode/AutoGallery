using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Domain.Entities
{
	public class CarExpertise : BaseEntity
	{
		public string EngineHood { get; set; }      
		public string Roof { get; set; }          
		public string FrontBumper { get; set; }    
		public string RearBumper { get; set; }      
		public string FrontLeftDoor { get; set; }   
		public string RearLeftDoor { get; set; }   
		public string FrontRightDoor { get; set; }  
		public string RearRightDoor { get; set; } 
		public string FrontLeftFender { get; set; } 
		public string RearLeftFender { get; set; }  
		public string FrontRightFender { get; set; } 
		public string RearRightFender { get; set; } 
		public string TrunkCover { get; set; }     

		public string GeneralCondition { get; set; }

		public int CarId { get; set; }
		public Car Car { get; set; }
	}
}
