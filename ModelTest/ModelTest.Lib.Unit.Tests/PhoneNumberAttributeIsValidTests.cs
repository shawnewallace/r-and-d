using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelTest.Lib.DataAnnotations;
using NUnit.Framework;

namespace ModelTest.Lib.Unit.Tests
{
	[TestFixture]
	public class PhoneNumberAttributeIsValidTests
	{
		private PhoneNumberAttribute _subjectUnderTest;

		[SetUp]
		public void SetUp()
		{
			_subjectUnderTest = new PhoneNumberAttribute();
		}

		[Test]
		public void null_number_is_valid()
		{
			Assert.True(_subjectUnderTest.IsValid(null));
		}

		[Test]
		public void empty_number_id_valid()
		{
			Assert.True(_subjectUnderTest.IsValid(string.Empty));
		}

		[TestCase("+4527122799")]
    [TestCase("6503181051")]
    [TestCase("+16503181051")]
    [TestCase("1-650-318-1051")]
    [TestCase("+1-650-318-1051")]
    [TestCase("+1650-318-1051")]
		public void valid_numbers(string number)
		{
			Assert.True(_subjectUnderTest.IsValid(number));
		}

		[TestCase("123")]
		[TestCase("foo")]
		public void invalid_numbers(string number)
		{
			Assert.False(_subjectUnderTest.IsValid(number));
		}
	}
}
