using AutoGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Infrastructure.Contexts
{
	public static class DbInitializer
	{
		public static void Seed(ApplicationDbContext context)
		{
			context.Database.Migrate();

			//if (!context.Cars.Any())
			//{
			//	// 1. Kategorileri Ekle
			//	var catIcDonanim = new FeatureCategory { Name = "İç Donanım" };
			//	var catDisDonanim = new FeatureCategory { Name = "Dış Donanım" };
			//	context.FeatureCategories.AddRange(catIcDonanim, catDisDonanim);
			//	context.SaveChanges();

			//	var featDeri = new Feature
			//	{
			//		Name = "Deri Döşeme",
			//		FeatureCategoryId = catIcDonanim.Id,
			//		Icon = "fa-solid fa-couch" 
			//	};

			//	var featKoltukIsitma = new Feature
			//	{
			//		Name = "Koltuk Isıtma",
			//		FeatureCategoryId = catIcDonanim.Id,
			//		Icon = "fa-solid fa-temperature-arrow-up" 
			//	};

			//	var featLedFar = new Feature
			//	{
			//		Name = "LED Farlar",
			//		FeatureCategoryId = catDisDonanim.Id,
			//		Icon = "fa-regular fa-lightbulb"
			//	};

			//	context.Features.AddRange(featDeri, featKoltukIsitma, featLedFar);
			//	context.SaveChanges();

			//	var car1 = new Car
			//	{
			//		Title = "Hatasız Boyasız İlk Sahibinden", 
			//		Brand = "Mercedes-Benz",
			//		Model = "C200 AMG",
			//		Year = 2021,
			//		Price = 2450000,
			//		IsFeatured = true,
			//		IsSold = false,
			//		Color = "Siyah",            
			//		FuelType = "Benzin",        
			//		GearType = "Otomatik",      
			//		Kilometer = 31200,          
			//		BodyType = "Sedan",         
			//		EngineCapacity = "1.5",    
			//		HorsePower = "184 hp",      
			//		Description = "Aracımız yetkili servis bakımlıdır." 
			//	};

			//	var car2 = new Car
			//	{
			//		Title = "Sıfır Ayarında Kapalı Garaj Arabası", 
			//		Brand = "BMW",
			//		Model = "3.20i Luxury Line",
			//		Year = 2022,
			//		Price = 2180000,
			//		IsFeatured = true,
			//		IsSold = false,
			//		Color = "Beyaz",
			//		FuelType = "Benzin",
			//		GearType = "Otomatik",
			//		Kilometer = 18400,
			//		BodyType = "Sedan",
			//		EngineCapacity = "1.6",
			//		HorsePower = "170 hp",
			//		Description = "Yedek anahtarı mevcuttur."
			//	};

			//	var car3 = new Car
			//	{
			//		Title = "Acil Satılık Temiz A4",
			//		Brand = "Audi",
			//		Model = "A4 40 TDI S Line",
			//		Year = 2020,
			//		Price = 1890000,
			//		IsFeatured = false,
			//		IsSold = true,
			//		Color = "Gri",
			//		FuelType = "Dizel",
			//		GearType = "Otomatik",
			//		Kilometer = 44900,
			//		BodyType = "Sedan",
			//		EngineCapacity = "2.0",
			//		HorsePower = "190 hp",
			//		Description = "Ağır bakımları yeni yapılmıştır."
			//	};

			//	context.Cars.AddRange(car1, car2, car3);
			//	context.SaveChanges();

			//	context.CarFeatures.AddRange(
			//		new CarFeature { CarId = car1.Id, FeatureId = featDeri.Id },
			//		new CarFeature { CarId = car1.Id, FeatureId = featKoltukIsitma.Id },
			//		new CarFeature { CarId = car2.Id, FeatureId = featLedFar.Id }
			//	);
			//	context.SaveChanges();

			//	context.CarExpertises.Add(new CarExpertise
			//	{
			//		CarId = car1.Id,
			//	});
			//	context.SaveChanges();
			//}
		}
	}
}
