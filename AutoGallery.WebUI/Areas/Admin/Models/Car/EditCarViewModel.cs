using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoGallery.Domain.Entities;

namespace AutoGallery.WebUI.Areas.Admin.Models.Car
{
	public class EditCarViewModel : ICarViewModel
	{
		public int Id { get; set; }

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
		public bool IsSold { get; set; }

		public List<IFormFile>? UploadedImages { get; set; }
		public int MainImageIndex { get; set; }

		[ValidateNever]
		public List<CarImage> ExistingImages { get; set; } = new();

		[ValidateNever]
		public CarExpertiseInput Expertise { get; set; } = new();

		[ValidateNever]
		public List<int> SelectedFeatureIds { get; set; } = new();

		[ValidateNever]
		public List<FeatureCategoryItem> FeatureCategories { get; set; } = new();
	}
}
