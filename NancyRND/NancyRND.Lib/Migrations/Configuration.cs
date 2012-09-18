namespace NancyRND.Lib.Migrations
{
		using System;
		using System.Data.Entity;
		using System.Data.Entity.Migrations;
		using System.Linq;

		internal sealed class Configuration : DbMigrationsConfiguration<NancyRND.Lib.BookContext>
		{
				public Configuration()
				{
						AutomaticMigrationsEnabled = false;
				}

				protected override void Seed(BookContext context)
				{
						//  This method will be called after migrating to the latest version.

						//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
						//  to avoid creating duplicate seed data. E.g.
						//
					context.Books.AddOrUpdate(
						p => p.Title,
						new Book { Title = "War and Peace", WhenEntered = DateTime.Now},
						new Book { Title = "Eloquent Ruby", WhenEntered = DateTime.Now },
						new Book { Title = "Clean Code", WhenEntered = DateTime.Now }
					);
						
				}
		}
}
