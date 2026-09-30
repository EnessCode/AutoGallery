using AutoGallery.Domain.Entities;

namespace AutoGallery.WebUI.Areas.Admin.Models.Dashboard
{
	public class DashboardViewModel
	{
		public int SoldCars { get; set; }
		public int TotalCars { get; set; }
		public int FeaturedCarsCount { get; set; }
		public int TotalConsignments { get; set; }
		public int PendingConsignments { get; set; }
		public List<ConsignmentRequest> RecentConsignments { get; set; }
		public List<Domain.Entities.Car> RecentCars { get; set; }
	}
}
