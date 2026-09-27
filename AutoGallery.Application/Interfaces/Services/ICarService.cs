using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Services
{
	public interface ICarService
	{
		Task<List<Car>> GetAllCarsAsync();
		Task<List<Car>> GetFeaturedCarsAsync();
		Task<Car> GetCarDetailsAsync(int id);
		Task CreateCarAsync(Car car);
		Task UpdateCarAsync(Car car);
		Task DeleteCarAsync(int id);
	}
}
