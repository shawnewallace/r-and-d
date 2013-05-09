using Microsoft.AspNet.SignalR.Hubs;

namespace BundlerAndSignalR.Web.Hubs
{
	public class TestHub : Hub
	{
		private static int _count = 0;
		public void Update()
		{
			_count++;
			Clients.All.addMessage(_count);
		}
	}
}