using AutoGallery.Domain.Entities;
using AutoGallery.WebUI.Areas.Admin.Models.Car;

namespace AutoGallery.WebUI.Areas.Admin.Helpers
{
	public static class CarMappingExtensions
	{
		public static Car ToEntity(this CreateCarViewModel vm, List<CarImage> images)
		{
			var car = new Car
			{
				Title = vm.Title,
				Brand = vm.Brand,
				Model = vm.Model,
				Year = vm.Year,
				Price = vm.Price,
				Kilometer = vm.Kilometer,
				FuelType = vm.FuelType,
				GearType = vm.GearType,
				Color = vm.Color,
				BodyType = vm.BodyType,
				EngineCapacity = vm.EngineCapacity,
				HorsePower = vm.HorsePower,
				Description = vm.Description,
				IsFeatured = vm.IsFeatured,
				IsSold = false,
				CarImages = images,
				Expertise = new CarExpertise()
			};
			car.Expertise.MapExpertise(vm.Expertise);
			return car;
		}

		public static EditCarViewModel ToEditViewModel(this Car car)
		{
			var vm = new EditCarViewModel
			{
				Id = car.Id,
				Title = car.Title,
				Brand = car.Brand,
				Model = car.Model,
				Year = car.Year,
				Price = car.Price,
				Kilometer = car.Kilometer,
				FuelType = car.FuelType,
				GearType = car.GearType,
				Color = car.Color,
				BodyType = car.BodyType,
				EngineCapacity = car.EngineCapacity,
				HorsePower = car.HorsePower,
				Description = car.Description,
				IsFeatured = car.IsFeatured,
				IsSold = car.IsSold,
				ExistingImages = car.CarImages?.ToList() ?? new List<CarImage>(),
				SelectedFeatureIds = car.CarFeatures?.Select(cf => cf.FeatureId).ToList() ?? new List<int>()
			};

			if (car.Expertise != null)
			{
				vm.Expertise = new CarExpertiseInput();
				vm.Expertise.EngineHood = car.Expertise.EngineHood;
				vm.Expertise.Roof = car.Expertise.Roof;
				vm.Expertise.TrunkCover = car.Expertise.TrunkCover;
				vm.Expertise.FrontBumper = car.Expertise.FrontBumper;
				vm.Expertise.RearBumper = car.Expertise.RearBumper;
				vm.Expertise.FrontLeftFender = car.Expertise.FrontLeftFender;
				vm.Expertise.FrontRightFender = car.Expertise.FrontRightFender;
				vm.Expertise.RearLeftFender = car.Expertise.RearLeftFender;
				vm.Expertise.RearRightFender = car.Expertise.RearRightFender;
				vm.Expertise.FrontLeftDoor = car.Expertise.FrontLeftDoor;
				vm.Expertise.FrontRightDoor = car.Expertise.FrontRightDoor;
				vm.Expertise.RearLeftDoor = car.Expertise.RearLeftDoor;
				vm.Expertise.RearRightDoor = car.Expertise.RearRightDoor;
				vm.Expertise.GeneralCondition = car.Expertise.GeneralCondition;
			}
			return vm;
		}

		public static void UpdateFromEditModel(this Car car, EditCarViewModel vm)
		{
			car.Title = vm.Title; car.Brand = vm.Brand; car.Model = vm.Model; car.Year = vm.Year; car.Price = vm.Price;
			car.Kilometer = vm.Kilometer; car.FuelType = vm.FuelType; car.GearType = vm.GearType; car.Color = vm.Color;
			car.BodyType = vm.BodyType; car.EngineCapacity = vm.EngineCapacity; car.HorsePower = vm.HorsePower;
			car.Description = vm.Description; car.IsFeatured = vm.IsFeatured; car.IsSold = vm.IsSold;
		}

		public static void MapExpertise(this CarExpertise expertise, CarExpertiseInput vm)
		{
			if (vm == null) return;
			expertise.EngineHood = vm.EngineHood; expertise.Roof = vm.Roof; expertise.TrunkCover = vm.TrunkCover;
			expertise.FrontBumper = vm.FrontBumper; expertise.RearBumper = vm.RearBumper;
			expertise.FrontLeftFender = vm.FrontLeftFender; expertise.FrontRightFender = vm.FrontRightFender;
			expertise.RearLeftFender = vm.RearLeftFender; expertise.RearRightFender = vm.RearRightFender;
			expertise.FrontLeftDoor = vm.FrontLeftDoor; expertise.FrontRightDoor = vm.FrontRightDoor;
			expertise.RearLeftDoor = vm.RearLeftDoor; expertise.RearRightDoor = vm.RearRightDoor;
			expertise.GeneralCondition = vm.GeneralCondition;
		}
	}
}
