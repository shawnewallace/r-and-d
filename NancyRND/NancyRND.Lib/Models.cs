using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace NancyRND.Lib
{
	public class BookContext : DbContext
	{
		public DbSet<Book> Books { get; set; }
	}

	[Table("books")]
	public class Book
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Column("title")]
		public string Title { get; set; }

		[Column("when_entered")]
		public DateTime? WhenEntered { get; set; }
	}
}
