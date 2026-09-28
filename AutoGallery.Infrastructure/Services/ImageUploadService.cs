using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Infrastructure.Services
{
	public class ImageUploadService : IImageUploadService
	{
		private readonly IWebHostEnvironment _env;
		private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };

		public ImageUploadService(IWebHostEnvironment env)
		{
			_env = env;
		}

		public async Task<List<CarImage>> SaveCarImagesAsync(List<IFormFile>? files, int mainIndex)
		{
			var result = new List<CarImage>();
			if (files == null || files.Count == 0) return result;

			var folder = Path.Combine(_env.WebRootPath, "uploads", "cars");
			Directory.CreateDirectory(folder);

			for (int i = 0; i < files.Count; i++)
			{
				var file = files[i];
				var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
				if (file.Length == 0 || !AllowedExtensions.Contains(ext)) continue;

				var fileName = $"{Guid.NewGuid():N}{ext}";
				await using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				result.Add(new CarImage
				{
					ImageUrl = $"/uploads/cars/{fileName}",
					IsMain = i == mainIndex
				});
			}

			if (result.Count > 0 && !result.Any(x => x.IsMain))
				result[0].IsMain = true;

			return result;
		}
	}
}
