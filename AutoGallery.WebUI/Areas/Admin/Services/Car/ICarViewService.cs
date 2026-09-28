using AutoGallery.WebUI.Areas.Admin.Models.Car;

namespace AutoGallery.WebUI.Areas.Admin.Services.Car
{
	public interface ICarViewService
	{
		Task<T> FillFeatureCategoriesAsync<T>(T model) where T : ICarViewModel;
	}
}
