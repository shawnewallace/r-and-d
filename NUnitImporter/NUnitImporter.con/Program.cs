using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NUnitImporter.con
{

	public class TestResults
	{
		public string Name { get; set; }
		public int Total { get; set; }
		public int Errors { get; set; }
		public int Failures { get; set; }
		public int NotRun { get; set; }
		public int Inconclusive { get; set; }
		public int Ignored { get; set; }
		public int Invalid { get; set; }
		public DateTime Date { get; set; }

		public TestEnvironment Environment { get; set; }
		public CultureInformation Culture { get; set; }

		public TestSuite TestSuite { get; set; }
	}

	public class TestSuite
	{
		public List<TestSuite> Results { get; set; }
	}
	
	public class CultureInformation
	{
		public string CurrentCulture { get; set; }
		public string CurrentUiCulture { get; set; }
	}

	public class TestEnvironment
	{
		public string NunitVersion { get; set; }
		public string ClrVersion { get; set; }
		public string OsVersion { get; set; }
		public string Platform { get; set; }
		public string WorkingDirectory { get; set; }
		public string MachineName { get; set; }
		public string User { get; set; }
		public string UserDomain { get; set; }
	}

	class Program
	{
		private const string IMP = @"\\GAINIMGP02\AcceptanceTestOutput\CI_Bop_Unit_Tests_20121218.13-nunit.xml";

		static void Main(string[] args)
		{
			var doc = XDocument.Load(IMP);

			Console.WriteLine(doc);

			using (var reader = new StreamReader(IMP))
			{
				while (reader.Peek() != -1)
				{
					Console.WriteLine(reader.ReadLine().TrimStart());
				}
			}

			Console.ReadLine();
		}
	}
}
