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
	public class AboutInfoService : IAboutInfoService
	{
		private readonly IAboutInfoRepository _repository;

		public AboutInfoService(IAboutInfoRepository repository)
		{
			_repository = repository;
		}

		public async Task<AboutInfo> GetAboutInfoAsync()
		{
			var values = await _repository.GetAllAsync();
			return values.FirstOrDefault() ?? new AboutInfo();
		}

		public async Task UpdateAboutInfoAsync(AboutInfo aboutInfo)
		{
			var existing = await _repository.GetByIdAsync(aboutInfo.Id);

			if (existing == null)
			{
				await _repository.AddAsync(aboutInfo);
			}
			else
			{
				existing.TopTitle = aboutInfo.TopTitle;
				existing.Description1 = aboutInfo.Description1;
				existing.Description2 = aboutInfo.Description2;

				existing.Stat1Value = aboutInfo.Stat1Value;
				existing.Stat1Text = aboutInfo.Stat1Text;
				existing.Stat1Icon = aboutInfo.Stat1Icon;

				existing.Stat2Value = aboutInfo.Stat2Value;
				existing.Stat2Text = aboutInfo.Stat2Text;
				existing.Stat2Icon = aboutInfo.Stat2Icon;

				existing.Stat3Value = aboutInfo.Stat3Value;
				existing.Stat3Text = aboutInfo.Stat3Text;
				existing.Stat3Icon = aboutInfo.Stat3Icon;

				existing.Stat4Value = aboutInfo.Stat4Value;
				existing.Stat4Text = aboutInfo.Stat4Text;
				existing.Stat4Icon = aboutInfo.Stat4Icon;

				_repository.Update(existing);
			}
		}
	}
}