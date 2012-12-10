using System;
using System.Collections.Generic;
using System.Text;
using GridSpike.Lib.Data;
using GridSpike.Lib.Model;

namespace GridSpike.Lib
{
	public class TestQueuer
	{
		private GridSpikeContext _db;

		public TestQueuer(GridSpikeContext db)
		{
			_db = db;
		}

		public string Feature { get; set; }
		public string Scenario { get; set; }
		public string TargetEnvironment { get; set; }

		public QueuedTest Execute()
		{
			var newQItem = new QueuedTest
			{
				Feature = Feature,
				Scenario = Scenario,
				TargetEnvironment = TargetEnvironment,
				WhenCreated = DateTime.Now
			};

			_db.Queue.Add(newQItem);
			_db.SaveChanges();

			return newQItem;
		}
	}
}
