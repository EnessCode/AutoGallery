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
	public class GalleryInfoService : IGalleryInfoService
	{
		private readonly IGalleryInfoRepository _repository;

		public GalleryInfoService(IGalleryInfoRepository repository)
		{
			_repository = repository;
		}

		public async Task<GalleryInfo> GetGalleryInfoAsync()
		{
			var values = await _repository.GetAllAsync();
			return values.FirstOrDefault() ?? new GalleryInfo();
		}

		public async Task UpdateGalleryInfoAsync(GalleryInfo galleryInfo)
		{
			var existing = await _repository.GetByIdAsync(galleryInfo.Id);

			if (existing == null)
			{
				await _repository.AddAsync(galleryInfo);
			}
			else
			{
				existing.Title = galleryInfo.Title;
				existing.Address = galleryInfo.Address;
				existing.Phone1 = galleryInfo.Phone1;
				existing.Phone2 = galleryInfo.Phone2;
				existing.Email = galleryInfo.Email;
				existing.WorkingHoursWeekdays = galleryInfo.WorkingHoursWeekdays;
				existing.WorkingHoursWeekend = galleryInfo.WorkingHoursWeekend;
				existing.GoogleMapUrl = galleryInfo.GoogleMapUrl;
				existing.InstagramUrl = galleryInfo.InstagramUrl;
				existing.LinkedinUrl = galleryInfo.LinkedinUrl;
				existing.YoutubeUrl = galleryInfo.YoutubeUrl;

				_repository.Update(existing);
			}
		}
	}
}
