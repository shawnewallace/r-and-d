using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace migration_rnd
{
	public class MigrationTestContext : DbContext
	{
		public DbSet<MyThing> MyThings { get; set; }
	}

	public class MyThing
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }

		public DateTime? CreatedDate { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new MigrationTestContext())
			{
				for (var i = 0; i < 100; i++)
				{
					var newThing = db.MyThings.Add(new MyThing {FirstName = Guid.NewGuid().ToString()});
					Console.WriteLine("added newThing - " + newThing.FirstName);
				}
				db.SaveChanges();
			}

			Console.ReadLine();
		}
	}
}
