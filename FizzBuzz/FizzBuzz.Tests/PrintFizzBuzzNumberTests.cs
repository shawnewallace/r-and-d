using System;
using FizzBuzz.Lib;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
	[TestFixture]
	public class PrintFizzBuzzNumberTests
	{
		private FizzBuzzPrinter _printer;

		[SetUp]
		public void SetUp()
		{
			_printer = new FizzBuzzPrinter();
		}

		[Test, ExpectedException(typeof(ArgumentException))]
		public void throws_exception() { _printer.Calculate(0); }

		[TestCase(1, "1")]
		[TestCase(3, "Fizz")]
		[TestCase(4, "4")]
		[TestCase(5, "Buzz")]
		[TestCase(15, "Fizz Buzz")]
		[TestCase(20, "Buzz")]
		public void OutputIsExpected(int num, string expected) 
		{
			Assert.AreEqual(expected, _printer.Calculate(num), "FAILED");
		}
	}
}
