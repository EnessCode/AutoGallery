using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Services
{
	public interface IImageUploadService
	{
		Task<List<CarImage>> SaveCarImagesAsync(List<IFormFile>? files, int mainIndex);
	}
}
