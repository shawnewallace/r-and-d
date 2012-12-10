using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GridSpike.Lib;
using NUnit.Framework;

namespace GridSpike.Tests.Unit.TestQueueServiceTests
{
	[TestFixture]
	public class CountTests
	{
		private TestQueueService service;

		[SetUp]
		public void SetUp()
		{
			service = new TestQueueService();
			service.Initialize();
		}

		[Test]
		public void when_queue_is_empty_count_is_zero()
		{

			Assert.AreEqual(0, service.Count);
		}

		[Test]
		public void when_queue_is_empty_add_one_count_is_one()
		{
			service.Push(new TestQueueRequest {Feature = "feature", Scenario = "scenario", Environment = "env"});

			Assert.AreEqual(1, service.Count);
		}

		[Test]
		public void when_add_two_count_is_two()
		{
			service.Push(new TestQueueRequest { Feature = "feature", Scenario = "scenario", Environment = "env" });
			service.Push(new TestQueueRequest { Feature = "feature", Scenario = "scenario", Environment = "env" });

			Assert.AreEqual(2, service.Count);
		}
	}
}
