using System.Data.Entity;
using Domain.Models;

namespace Domain.Context
{
	public class InventoryContext : DbContext
	{
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			Database.SetInitializer(new DropCreateDatabaseAlways<InventoryContext>());
			base.OnModelCreating(modelBuilder);
		}
	}
}
