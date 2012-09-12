using System.Linq;
using ModelTest.Lib.Data;
using ModelTest.Lib.Models;

namespace ModelTest.Lib.Migrations
{
	using System.Data.Entity;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<ModelTestContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ModelTestContext context)
		{
			Database.SetInitializer<ModelTestContext>(new MigrateDatabaseToLatestVersion<ModelTestContext, Configuration>());

			if (!context.Events.Any())
			{
				context.Events.Add(new Event {Name = "CodeMash 2.0.1.3"});
			}

			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//
		}
	}
}
