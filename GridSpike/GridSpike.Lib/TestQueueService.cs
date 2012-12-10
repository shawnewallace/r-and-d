using System;
using System.Collections.Generic;
using GridSpike.Lib.Model;

namespace GridSpike.Lib
{
	public interface ITestQueueService
	{
		int Count { get; }
		void Initialize();
		QueuedTest Push(TestQueueRequest request);
		QueuedTest Pop();
	}

	public class TestQueueService : ITestQueueService
	{
		private static Queue<QueuedTest> Q
		{
			get { return _q ?? (_q = new Queue<QueuedTest>()); }
			set { _q = value; }
		}
		private static Queue<QueuedTest> _q;
		
		public int Count { get { return Q.Count; } }

		public void Initialize()
		{
			Q = new Queue<QueuedTest>();
		}

		public QueuedTest Push(TestQueueRequest request)
		{
			var test = CreateFromRequest(request);
			Q.Enqueue(test);
			return test;
		}

		public QueuedTest Pop()
		{
			return Q.Dequeue();
		}

		private QueuedTest CreateFromRequest(TestQueueRequest request)
		{
			return new QueuedTest
			{
				Feature = request.Feature,
				Scenario = request.Scenario,
				TargetEnvironment = request.Environment,
				WhenCreated = DateTime.Now
			};
		}
	}
}