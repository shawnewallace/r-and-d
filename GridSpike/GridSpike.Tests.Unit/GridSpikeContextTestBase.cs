using System.Data.Entity;
using GridSpike.Lib;
using GridSpike.Lib.Data;
using GridSpike.Lib.Model;
using NUnit.Framework;

namespace GridSpike.Tests.Unit
{
	public class GridSpikeContextTestBase
	{
		protected GridSpikeContext DB;

		[SetUp]
		public void SetUp()
		{
			Database.SetInitializer(new DropCreateDatabaseAlways<GridSpikeContext>());
			DB = new GridSpikeContext();
			DB.Database.ExecuteSqlCommand("delete from queued_tests;");
		}

		protected QueuedTest QueueATest(string feature, string scenario)
		{
			var qer = new TestQueuer(DB)
			{
				Feature = feature,
				Scenario = scenario,
				TargetEnvironment = "ENV GET"
			};

			return qer.Execute();
		}
	}
}