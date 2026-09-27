using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AutoGallery.Application.Interfaces.Repositories
{
	public interface IRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		Task<List<T>> GetAllAsync();
		Task<List<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
		Task AddAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
