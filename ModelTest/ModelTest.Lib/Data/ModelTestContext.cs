using System.Data.Entity;
using ModelTest.Lib.Models;

namespace ModelTest.Lib.Data
{
	public class ModelTestContext : DbContext
	{
		public ModelTestContext() : base("DefaultConnection") { }

		public DbSet<Attendee> Attendees { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Event> Events { get; set; }
	}
}
