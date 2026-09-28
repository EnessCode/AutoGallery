using AutoGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Services
{
	public interface IAboutInfoService
	{
		Task<AboutInfo> GetAboutInfoAsync();
		Task UpdateAboutInfoAsync(AboutInfo aboutInfo);
	}
}
