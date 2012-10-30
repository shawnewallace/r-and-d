using FizzBuzz.Lib;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
	public class SwapperTestClass
	{
		public int    Id   { get; set; }
		public string Name { get; set; }
	}

	[TestFixture]
	public class SwapperTests
	{
		[Test]
		public void should_be_swapped_for_simple_type()
		{
			var swapper = new Swapper<int>();

			var i = 5;
			var j = 10;

			swapper.Execute(ref i, ref j);

			Assert.AreEqual(5, j);
			Assert.AreEqual(10, i);
		}

		[Test]
		public void should_be_swapped_for_complex_type()
		{
			var swapper = new Swapper<SwapperTestClass>();

			var left = new SwapperTestClass { Id = 0, Name = "OLD LEFT" };
			var right = new SwapperTestClass { Id = 1, Name = "OLD RIGHT" };

			swapper.Execute(ref left, ref right);

			Assert.AreEqual(1, left.Id);
			Assert.AreEqual("OLD RIGHT", left.Name);
			Assert.AreEqual(0, right.Id);
			Assert.AreEqual("OLD LEFT", right.Name);
		}
	}
}
