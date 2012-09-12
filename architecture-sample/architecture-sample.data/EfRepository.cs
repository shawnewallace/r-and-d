using System;
using System.Data.Entity;
using System.Linq;
using architecture_sample.core;

namespace architecture_sample.data
{
	public class EfRepository<T, TKey> : IRepository<T, TKey>
		where T : class, IEntity<TKey>
	{
		public IUnitOfWork UnitOfWork { get; set; }

		private IDbSet<T> _objectset;
		private IDbSet<T> ObjectSet
		{
			get { return _objectset ?? (_objectset = UnitOfWork.Context.Set<T>()); }
		}

		public EfRepository() { }
		public EfRepository(IUnitOfWork unitOfWork) { UnitOfWork = unitOfWork; }

		public IQueryable<T> All()
		{
			return ObjectSet.AsQueryable();
		}

		public IQueryable<T> Where(Func<T, bool> expression)
		{
			return ObjectSet.Where(expression).AsQueryable();
		}

		public T GetById(TKey id)
		{
			return Where(e => e.Id.Equals(id)).First();
		}

		public T Add(T entity)
		{
			var x = ObjectSet.Add(entity);
			return x;
		}

		public void Delete(T entity)
		{
			ObjectSet.Remove(entity);
		}

		public void DeleteById(TKey id)
		{
			var entityToDelete = GetById(id);
			Delete(entityToDelete);
		}
	}
}