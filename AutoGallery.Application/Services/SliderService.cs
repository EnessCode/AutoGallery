using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Services
{
	public class SliderService : ISliderService
	{
		private readonly ISliderRepository _sliderRepository;

		public SliderService(ISliderRepository sliderRepository)
		{
			_sliderRepository = sliderRepository;
		}

		public async Task<List<Slider>> GetActiveSlidersAsync()
		{
			return await _sliderRepository.GetActiveSlidersAsync();
		}

		public async Task<List<Slider>> GetAllSlidersAsync()
		{
			return await _sliderRepository.GetAllAsync();
		}

		public async Task<Slider> GetSliderByIdAsync(int id)
		{
			return await _sliderRepository.GetByIdAsync(id);
		}

		public async Task CreateSliderAsync(Slider slider)
		{
			await _sliderRepository.AddAsync(slider);
		}

		public async Task UpdateSliderAsync(Slider slider)
		{
			slider.CreatedAt = DateTime.SpecifyKind(slider.CreatedAt, DateTimeKind.Utc);
			_sliderRepository.Update(slider);
			await Task.CompletedTask;
		}

		public async Task DeleteSliderAsync(int id)
		{
			var slider = await _sliderRepository.GetByIdAsync(id);
			if (slider != null)
			{
				_sliderRepository.Delete(slider);
			}
		}
	}
}
