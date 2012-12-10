using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
	public class ThisContext : DbContext
	{
		public DbSet<Parent> Parents { get; set; }
		public DbSet<Child> Children { get; set; }
	}

	public class Parent
	{
		[Key]
		public Guid Id { get; set; }

		public string Name { get; set; }

		public virtual List<Child> Children { get; set; }
	}

	public class Child
	{
		[Key]
		public Guid Id { get; set; }

		public Guid ParentId { get; set; }
		public virtual Parent Parent { get; set; }
	}
}
