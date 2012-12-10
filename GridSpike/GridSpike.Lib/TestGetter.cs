using System;
using System.Data;
using System.Linq;
using GridSpike.Lib.Data;
using GridSpike.Lib.Model;

namespace GridSpike.Lib
{
	public class TestCompleter
	{
		private GridSpikeContext _db;

		public TestCompleter(GridSpikeContext db)
		{
			_db = db;
		}

		public int Id { get; set; }

		public QueuedTest Execute()
		{
			var test = _db.Queue.Where(q => q.Id == Id).FirstOrDefault();
			if (test == null) return null;

			test.CompletedOn = DateTime.Now;

			_db.Entry(test).State = EntityState.Modified;
			_db.SaveChanges();

			return test;
		}
	}

	public class TestGetter
	{
		private GridSpikeContext _db;

		public TestGetter(GridSpikeContext db)
		{
			_db = db;
		}

		public string SelectedBy { get; set; }

		public QueuedTest Execute()
		{
			var test = _db.Queue
				.Where(q => !q.SelectedOn.HasValue)
				.OrderBy(q => q.WhenCreated)
				.ToList()
				.FirstOrDefault();

			if (test == null) return null;

			test.SelectedOn = DateTime.Now;
			test.SelectedBy = SelectedBy;
			test.WhenModified = DateTime.Now;

			_db.Entry(test).State = EntityState.Modified;
			_db.SaveChanges();

			return test;
		}
	}
}