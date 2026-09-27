using AutoGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Infrastructure.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<Car> Cars { get; set; }
		public DbSet<CarImage> CarImages { get; set; }
		public DbSet<CarExpertise> CarExpertises { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<FeatureCategory> FeatureCategories { get; set; } 
		public DbSet<CarFeature> CarFeatures { get; set; }
		public DbSet<CarSellRequest> CarSellRequests { get; set; }
		public DbSet<ContactMessage> ContactMessages { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Car>()
				.HasOne(c => c.Expertise)
				.WithOne(e => e.Car)
				.HasForeignKey<CarExpertise>(e => e.CarId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Car>()
				.HasMany(c => c.CarImages)
				.WithOne(i => i.Car)
				.HasForeignKey(i => i.CarId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<FeatureCategory>()
				.HasMany(fc => fc.Features)
				.WithOne(f => f.FeatureCategory)
				.HasForeignKey(f => f.FeatureCategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<CarFeature>()
				.HasOne(cf => cf.Car)
				.WithMany(c => c.CarFeatures)
				.HasForeignKey(cf => cf.CarId);

			modelBuilder.Entity<CarFeature>()
				.HasOne(cf => cf.Feature)
				.WithMany(f => f.CarFeatures)
				.HasForeignKey(cf => cf.FeatureId);
		}
	}
}
