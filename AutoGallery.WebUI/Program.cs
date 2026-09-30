using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Application.Interfaces.Services;
using AutoGallery.Application.Services;
using AutoGallery.Infrastructure.Contexts;
using AutoGallery.Infrastructure.Repositories;
using AutoGallery.Infrastructure.Services;
using AutoGallery.WebUI.Areas.Admin.Services.Car;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IFeatureCategoryRepository, FeatureCategoryRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IGalleryInfoRepository, GalleryInfoRepository>();
builder.Services.AddScoped<IAboutInfoRepository, AboutInfoRepository>();
builder.Services.AddScoped<ISliderRepository, SliderRepository>();
builder.Services.AddScoped<IExpertiseInfoRepository, ExpertiseInfoRepository>();
builder.Services.AddScoped<IConsignmentRequestRepository, ConsignmentRequestRepository>();
builder.Services.AddScoped<IAdminUserRepository, AdminUserRepository>();

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IFeatureCategoryService, FeatureCategoryService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<ICarFeatureService, CarFeatureService>();
builder.Services.AddScoped<IImageUploadService, ImageUploadService>();
builder.Services.AddScoped<ICarViewService, CarViewService>();
builder.Services.AddScoped<IGalleryInfoService, GalleryInfoService>();
builder.Services.AddScoped<IAboutInfoService, AboutInfoService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IExpertiseInfoService, ExpertiseInfoService>();
builder.Services.AddScoped<IConsignmentRequestService, ConsignmentRequestService>();
builder.Services.AddScoped<IAdminUserService, AdminUserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(options =>
	{
		options.Cookie.Name = "AutoGallery.Auth";
		options.LoginPath = "/Account/Login"; 
		options.LogoutPath = "/Account/Logout";
		options.ExpireTimeSpan = TimeSpan.FromDays(7);
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
	name: "areas",
	pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
	var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
	DbInitializer.Seed(context);
}

app.Run();
