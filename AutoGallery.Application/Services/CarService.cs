using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Services
{
	public class CarService : ICarService
	{
		private readonly ICarRepository _carRepository;

		public CarService(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		public async Task<List<Car>> GetAllCarsAsync(string search = null, string gear = null, string fuel = null, string body = null, string color = null)
		{
			return await _carRepository.GetFilteredCarsAsync(search, gear, fuel, body, color);
		}

		public async Task<List<Car>> GetFeaturedCarsAsync()
		{
			return await _carRepository.GetFeaturedCarsAsync();
		}

		public async Task<Car> GetCarDetailsAsync(int id)
		{
			return await _carRepository.GetCarWithDetailsByIdAsync(id);
		}

		public async Task CreateCarAsync(Car car)
		{
			await _carRepository.AddAsync(car);
		}

		public async Task UpdateCarAsync(Car car)
		{
			_carRepository.Update(car);
			await Task.CompletedTask;
		}

		public async Task DeleteCarAsync(int id)
		{
			var car = await _carRepository.GetByIdAsync(id);
			if (car != null)
			{
				_carRepository.Delete(car);
			}
		}
	}
}
