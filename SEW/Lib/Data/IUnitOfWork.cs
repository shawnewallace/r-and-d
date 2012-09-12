using System;
using System.Data.Entity;

namespace Lib.Data
{
	public interface IUnitOfWork : IDisposable
	{
		DbContext Context { get; set; }
		void Commit();
		bool LazyLoadingEnabled { get; set; }
	}
}