
using System.Data.Entity;
using architecture_sample.core;

namespace architecture_sample.data
{
	public class UnitOfWork : IUnitOfWork
	{
		public DbContext Context { get; set; }

		public UnitOfWork() { }
		public UnitOfWork(DbContext context)
		{
			Context = context;
		}

		public void Commit()
		{
			Context.SaveChanges();
		}
		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}
		public void Dispose()
		{
			Context.Dispose();
		}
	}
}