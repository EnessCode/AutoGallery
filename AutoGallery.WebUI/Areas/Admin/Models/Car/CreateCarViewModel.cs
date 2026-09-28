using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoGallery.WebUI.Areas.Admin.Models.Car
{
	public class CreateCarViewModel : ICarViewModel
	{
		[Required(ErrorMessage = "İlan başlığı zorunludur.")]
		public string Title { get; set; }

		[Required(ErrorMessage = "Marka zorunludur.")]
		public string Brand { get; set; }

		[Required(ErrorMessage = "Model zorunludur.")]
		public string Model { get; set; }

		[Required(ErrorMessage = "Yıl zorunludur.")]
		public int Year { get; set; }

		[Required(ErrorMessage = "Fiyat zorunludur.")]
		public decimal Price { get; set; }

		[Required(ErrorMessage = "Kilometre zorunludur.")]
		public int Kilometer { get; set; }

		public string? FuelType { get; set; }
		public string? GearType { get; set; }
		public string? Color { get; set; }
		public string? BodyType { get; set; }
		public string? EngineCapacity { get; set; }
		public string? HorsePower { get; set; }
		public string? Description { get; set; }

		public bool IsFeatured { get; set; }

		public List<IFormFile>? UploadedImages { get; set; }

		public int MainImageIndex { get; set; }

		[ValidateNever]
		public CarExpertiseInput Expertise { get; set; } = new();

		[ValidateNever]
		public List<int> SelectedFeatureIds { get; set; } = new();
		[ValidateNever]
		public List<FeatureCategoryItem> FeatureCategories { get; set; } = new();
	}

	public class CarExpertiseInput
	{
		public string EngineHood { get; set; } = "Orijinal";
		public string Roof { get; set; } = "Orijinal";
		public string TrunkCover { get; set; } = "Orijinal";
		public string FrontBumper { get; set; } = "Orijinal";
		public string RearBumper { get; set; } = "Orijinal";
		public string FrontLeftFender { get; set; } = "Orijinal";
		public string FrontLeftDoor { get; set; } = "Orijinal";
		public string RearLeftDoor { get; set; } = "Orijinal";
		public string RearLeftFender { get; set; } = "Orijinal";
		public string FrontRightFender { get; set; } = "Orijinal";
		public string FrontRightDoor { get; set; } = "Orijinal";
		public string RearRightDoor { get; set; } = "Orijinal";
		public string RearRightFender { get; set; } = "Orijinal";
		public string? GeneralCondition { get; set; }
	}

	public class FeatureCategoryItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<FeatureItem> Features { get; set; } = new();
	}

	public class FeatureItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Icon { get; set; }
	}
}
