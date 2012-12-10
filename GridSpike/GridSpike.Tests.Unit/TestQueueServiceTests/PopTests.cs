using GridSpike.Lib;
using NUnit.Framework;

namespace GridSpike.Tests.Unit.TestQueueServiceTests
{
	[TestFixture]
	public class PopTests
	{
		private TestQueueService service;

		[SetUp]
		public void SetUp()
		{
			service = new TestQueueService();
			service.Initialize();
		}

		[Test]
		public void spike()
		{

			for (var i = 0; i < 10; i++)
			{
				service.Push(new TestQueueRequest()
										 {
											 Feature = "feature " + i.ToString(),
											 Scenario = "scenario " + i,
											 Environment = "env"
										 });
			}

			var item = service.Pop();

			Assert.AreEqual("feature 0", item.Feature);
		}
	}
}