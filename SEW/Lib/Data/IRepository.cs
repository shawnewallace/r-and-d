using System;
using System.Linq;

namespace Lib.Data
{
	public interface IRepository<T, TKey> where T : IEntity<TKey>
	{
		IUnitOfWork UnitOfWork { get; set; }
		IQueryable<T> All();
		IQueryable<T> Where(Func<T, bool> expression);
		T GetById(TKey id);
		TKey Add(T entity);
		void Delete(T entity);
		void DeleteById(TKey id);
	}
}