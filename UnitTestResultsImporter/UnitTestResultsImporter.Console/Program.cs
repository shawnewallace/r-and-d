using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTestResultsImporter.Console
{
	public class UnitTestResultsImporterContext : DbContext
	{
		public DbSet<TestRun> TestRuns { get; set; }
	}

	public class TestRun
	{
		public int Id { get; set; }
		public string Description { get; set; }
		public DateTime RunDate { get; set; }
		public decimal Duration { get; set; }
		public int NumberOfTests { get; set; }
		public string Status { get; set; }

		public int? TestRunId { get; set; }
		public virtual List<TestRun> TestGroups { get; set; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			string[] contents;
			using (var sr = new StreamReader(@"C:\Users\c-wallas\Desktop\specs.txt"))
			{
				contents = sr.ReadToEnd().Split('\n');
			}

			using (var db = new UnitTestResultsImporterContext())
			{
				int i = 0;
				foreach (var line in contents)
				{
					
					db.TestRuns.Add(new TestRun
					{
						Description = line,
						Duration = ExtractDuration(line),
						NumberOfTests = ExtractNumberOfTests(line),
						RunDate = DateTime.Now,
						Status = ExtractStatus(line)
					});

					if (i % 1000 == 0)
					{
						System.Console.Write("Saving changes...");
						db.SaveChanges();
						System.Console.WriteLine("Done");
					}

					i++;
				}

				System.Console.Write("Saving changes...");
				db.SaveChanges();
				System.Console.WriteLine("Done");
			}

			System.Console.WriteLine("SEW");
			System.Console.ReadLine();
		}

		private static string ExtractStatus(string line)
		{
			var startIndex = line.LastIndexOf(" ");
			return line.Substring(startIndex + 1);
		}

		private static int ExtractNumberOfTests(string line)
		{
			var startIndex = line.IndexOf('(');

			if (startIndex < 0) return 0;

			var value = line.Substring(startIndex + 1, line.IndexOf(" test", startIndex + 1) - startIndex - 1);
			return int.Parse(value);
		}

		private static decimal ExtractDuration(string line)
		{
			var startIndex = line.IndexOf('[');

			if (startIndex < 0) return 0;

			var value = line.Substring(startIndex + 1, line.IndexOf("]", startIndex + 1) - startIndex - 1);

			var split = value.Split(':');
			return (decimal.Parse(split[0]) * 60) + decimal.Parse(split[1]);
		}
	}
}
