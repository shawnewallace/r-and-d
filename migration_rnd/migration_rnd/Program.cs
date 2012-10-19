using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;

namespace migration_rnd
{
	public class MigrationTestContext : DbContext
	{
		public DbSet<MyThing> MyThings { get; set; }
		public DbSet<WhiskeyTangoFoxtrot> WhiskeyTangoFoxtrots { get; set; }
	}

	public class MyThing
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string FirstName { get; set; }

		public DateTime? CreatedDate { get; set; }
	}

	public class WhiskeyTangoFoxtrot
	{
		[Key] public Guid Id { get; set; }
		public DateTime Date { get; set; }
		public decimal Weight { get; set; }
		public string Note { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			//using (var db = new MigrationTestContext())
			//{
			//  for (var i = 0; i < 100; i++)
			//  {
			//    var newThing = db.MyThings.Add(new MyThing {FirstName = Guid.NewGuid().ToString()});
			//    Console.WriteLine("added newThing - " + newThing.FirstName);
			//  }
			//  db.SaveChanges();
			//}

			//Console.ReadLine();

			ReadWeightsFile();
			//Console.ReadLine();

			using (var db = new MigrationTestContext())
			{
				var values = db.WhiskeyTangoFoxtrots
											 .Select(wtf => wtf)
											 .OrderBy(wtf => wtf.Date)
											 .ToList();
				foreach (var w in values)
				{
					Console.WriteLine(w.Date.ToShortDateString() + " - " + w.Weight + " - " + w.Note + " - " + w.Id);
				}
			}

			Console.ReadLine();
		}

		private static void ReadWeightsFile()
		{
			var path = @"C:\Users\c-wallas\Desktop\r-and-d\migration_rnd\migration_rnd\measurements-weight-combined.csv";

			using (var db = new MigrationTestContext())
			{
				using (var reader = File.OpenText(path))
				{
					var skipFirstLine = reader.ReadLine();
					string line;
					while ((line = reader.ReadLine()) != null)
					{
						var fields = line.Split(',');
						var date = DateTime.Parse(string.Format("{0} {1}", fields[0], fields[1]));
						var value = decimal.Parse(fields[2]);
						var note = fields[3];

						//Console.WriteLine(date.ToShortDateString() + "," + value + "," + note);

						db.WhiskeyTangoFoxtrots.AddOrUpdate(
							wtf => wtf.Date,
							new WhiskeyTangoFoxtrot { Id = Guid.NewGuid(), Date = date, Weight = value, Note = note }
						);
					}
				}
				db.SaveChanges();
			}
		}
	}
}
