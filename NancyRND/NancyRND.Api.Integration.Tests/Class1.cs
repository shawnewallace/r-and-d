using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace NancyRND.Api.Integration.Tests
{
	[TestFixture]
	public class Class1
	{
		[Test]
		public void smoke_test()
		{
			// Given
			var bootstrapper = new DefaultNancyBootstrapper();
			var browser = new Browser(bootstrapper);

			// When
			var result = browser.Get("/books", with =>
			{
				with.HttpRequest();
			});

			// Then
			Assert.AreEqual(HttpStatusCode.OK.ToString(), result.StatusCode.ToString());
		}

		[Test]
		public void can_create_a_book()
		{
			var bootstrapper = new DefaultNancyBootstrapper();
			var browser = new Browser(bootstrapper);
			var newTitle = Guid.NewGuid().ToString();
			var result = browser.Post("/books/new", with =>
			{
				with.HttpRequest();
				with.FormValue("Title", newTitle);
			});

			Assert.AreEqual(HttpStatusCode.Created.ToString(), result.StatusCode.ToString());
		}

		[Test]
		public void can_delete_a_book()
		{
			var bootstrapper = new DefaultNancyBootstrapper();
			var browser = new Browser(bootstrapper);
			var result = browser.Delete("/books/destroy/1", with => with.HttpRequest());

			Assert.AreEqual(HttpStatusCode.OK.ToString(), result.StatusCode.ToString());
		}
	}
}