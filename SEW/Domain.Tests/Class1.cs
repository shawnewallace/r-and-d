using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interactors;
using NUnit.Framework;

namespace Domain.Tests
{
	[TestFixture]
	public class Class1
	{
		[Test]
		public void smoke_test()
		{
			var interactor = new CreateProductInteractor
			                 	{
			                 		Name = "My Product",
													Price = 10.50M
			                 	};
			var result = interactor.Execute();
			Assert.AreEqual("My Product", result.Name);
			Assert.AreEqual(10.50, result.Price);
		}
	}
}
