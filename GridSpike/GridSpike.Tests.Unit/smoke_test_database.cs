using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GridSpike.Tests.Unit
{
	[TestFixture]
	public class smoke_test_database : GridSpikeContextTestBase
	{
		[Test]
		public void queue_items()
		{
			var model = DB.Queue.Select(q => q).ToList();

			Assert.IsNotNull(model);
		}
	}
}
