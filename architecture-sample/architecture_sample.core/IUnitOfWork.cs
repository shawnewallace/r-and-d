using System;
using System.Data.Entity;

namespace architecture_sample.core
{
	public interface IUnitOfWork : IDisposable
	{
		DbContext Context { get; set; }
		void Commit();
		bool LazyLoadingEnabled { get; set; }
	}
}