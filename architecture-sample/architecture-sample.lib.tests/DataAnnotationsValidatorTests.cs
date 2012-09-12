using System.ComponentModel.DataAnnotations;
using architecture_sample.core;
using NUnit.Framework;

namespace architecture_sample.lib.tests
{
	[TestFixture]
	public class DataAnnotationsValidatorTests
	{
		private class ValidationTestClass
		{
			[Required(ErrorMessage = "FIELD IS REQUIRED")]
			public string RequiredField { get; set; }
			public string NotRequiredField { get; set; }
		}

		[Test]
		public void should_return_true_and_error_collection_should_be_null()
		{
			var instance = new ValidationTestClass
			               	{
			               		RequiredField = "Has Value"
			               	};
			var validator = new DataAnnotationsValidator();

			Assert.IsTrue(validator.TryValidate(instance));
			Assert.That(validator.ErrorCollection.Count == 0);
		}

		[Test]
		public void should_return_false_and_have_collection()
		{
			var instance = new ValidationTestClass();
			var validator = new DataAnnotationsValidator();

			Assert.IsFalse(validator.TryValidate(instance));
			Assert.That(validator.ErrorCollection.Count > 0);
		}
	}
}
