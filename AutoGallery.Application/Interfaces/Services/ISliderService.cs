using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Services
{
	public interface ISliderService
	{
		Task<List<Slider>> GetAllSlidersAsync();
		Task<Slider> GetSliderByIdAsync(int id);
		Task CreateSliderAsync(Slider slider);
		Task UpdateSliderAsync(Slider slider);
		Task DeleteSliderAsync(int id);
		Task<List<Slider>> GetActiveSlidersAsync();
	}
}
