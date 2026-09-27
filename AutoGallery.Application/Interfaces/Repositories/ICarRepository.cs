using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Repositories
{
	public interface ICarRepository : IRepository<Car>
	{
		Task<List<Car>> GetFeaturedCarsAsync();
		Task<Car> GetCarWithDetailsByIdAsync(int id);
	}
}
