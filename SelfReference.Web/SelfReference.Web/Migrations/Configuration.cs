using SelfReference.Web.Models;

namespace SelfReference.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

				protected override void Seed(WebContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
					context.Employees.AddOrUpdate(
						p => p.FirstName,
						new Employee { FirstName = "A", LastName = "B"},
						new Employee { FirstName = "C", LastName = "D"},
						new Employee { FirstName = "E", LastName = "F"}
					);
					
        }
    }
}
