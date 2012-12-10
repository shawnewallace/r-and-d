using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using GridSpike.Api;

namespace GridSpike.Tests.Unit.IntegrationTests
{
	[TestFixture]
	public class NoIdea
	{
		[Test]
		public void smoke()
		{
			var bootstrapper = new AppBootstrapper();
			var browser = new Browser(bootstrapper);
			bootstrapper.Initialise();

			var response = browser.Post("/queue/", (with) =>
			{
			  with.HttpRequest();
				with.FormValue("Feature", "feat");
				with.FormValue("Scenario", "sce");
				with.FormValue("Environment", "env");
			});

			Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
		}
	}
}