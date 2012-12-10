using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GridSpike.Lib;
using Nancy;
using Nancy.ModelBinding;

namespace GridSpike.Api
{
	public class TestQueueServiceModule : NancyModule
	{
		private ITestQueueService _queueService;
		public ITestQueueService QueueService
		{
			get { return _queueService ?? (_queueService = new TestQueueService()); }
			set { _queueService = value; }
		}

		public TestQueueServiceModule() : base("/queue")
		{
			Post["/"] = parameters =>
			{
				TestQueueRequest request = this.Bind();
				if(QueueService.Push(request) == null) return HttpStatusCode.ExpectationFailed ;
				return HttpStatusCode.OK;
			};

			Get["/"] = parameters =>
			{
				return QueueService.Pop();
			};
		}
	}
}