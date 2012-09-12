using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Context;
using Domain.Models;
using Domain.Repositories;
using Lib.Data;

namespace Console
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Product> result;
			using (var db = new EfUnitOfWork(new InventoryContext()))
			{
				var repo = new ProductRepository(db);

				repo.Add(new Product { Name = "One"});
				repo.Add(new Product { Name = "Two" });
				repo.Add(new Product { Name = "Three" });
				repo.Add(new Product { Name = "Four" });

				db.Commit();

				result = repo.All().ToList();
			}

			foreach (var item in result)
			{
				System.Console.WriteLine(item.Name);
			}

			System.Console.ReadLine();
		}
	}
}
