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
	public class ExpertiseInfoService : IExpertiseInfoService
	{
		private readonly IExpertiseInfoRepository _expertiseInfoRepository;

		public ExpertiseInfoService(IExpertiseInfoRepository expertiseInfoRepository)
		{
			_expertiseInfoRepository = expertiseInfoRepository;
		}

		public async Task<ExpertiseInfo> GetExpertiseInfoAsync()
		{
			return await _expertiseInfoRepository.GetExpertiseInfoAsync();
		}

		public async Task UpdateExpertiseInfoAsync(ExpertiseInfo expertiseInfo)
		{
			expertiseInfo.CreatedAt = DateTime.SpecifyKind(expertiseInfo.CreatedAt, DateTimeKind.Utc);

			_expertiseInfoRepository.Update(expertiseInfo);
			await Task.CompletedTask;
		}
	}
}
