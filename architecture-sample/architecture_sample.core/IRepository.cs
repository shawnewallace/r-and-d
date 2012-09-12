using System;
using System.Linq;

namespace architecture_sample.core
{
	public interface IRepository<T, TKey> where T : IEntity<TKey>
	{
		IUnitOfWork UnitOfWork { get; set; }
		IQueryable<T> All();
		IQueryable<T> Where(Func<T, bool> expression);
		T GetById(TKey id);
		T Add(T entity);
		void Delete(T entity);
		void DeleteById(TKey id);
	}
}
