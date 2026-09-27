using AutoGallery.Application.Interfaces.Repositories;
using AutoGallery.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoGallery.Infrastructure.Repositories
{
	public class EfRepository<T> : IRepository<T> where T : class
	{
		protected readonly ApplicationDbContext _context;

		public EfRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter)
		{
			return await _context.Set<T>().Where(filter).ToListAsync();
		}

		public async Task AddAsync(T entity)
		{
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
			_context.SaveChanges();
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
		}
	}
}
