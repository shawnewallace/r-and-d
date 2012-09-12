using architecture_sample.core;
using architecture_sample.lib.entities;
using architecture_sample.lib.interactors.ProfileInteractors;
using Moq;
using NUnit.Framework;
using architecture_sample.data;

namespace architecture_sample.lib.tests.InteractorTests.ProfileInteractorTests
{
	[TestFixture]
	public class AddProfileInteractorTests_invalid_class
	{
		[Test]
		public void returns_null()
		{
			var validatorMock = new Mock<IValidator>();
			validatorMock.Setup(v => v.TryValidate(It.IsAny<Profile>()))
				.Returns(false);

			var repoMock = new Mock<IRepository<Profile, int>>();

			var interactor = new AddProfileInteractor(repoMock.Object, validatorMock.Object)
			{
				FirstName = "Joe",
				LastName = "Smith",
				EmailAddress = "Joe@company.com"
			};

			Assert.IsNull(interactor.Execute());
		}
	}


	[TestFixture]
	public class AddProfileInteractorTests
	{
		private AddProfileInteractor _interactor;
		private Profile _result;

		[SetUp]
		public void SetUp()
		{
			var validatorMock = new Mock<IValidator>();
			validatorMock.Setup(v => v.TryValidate(It.IsAny<Profile>()))
				.Returns(true);

			var repoMock = new Mock<IRepository<Profile, int>>();
			repoMock.Setup(m => m.Add(It.IsAny<Profile>()))
				.Returns(new Profile
									{
										Id = 65,
										FirstName = "Joe",
										LastName = "Smith",
										EmailAddress = "Joe@company.com"
									});

			_interactor = new AddProfileInteractor(repoMock.Object, validatorMock.Object)
			{
				FirstName = "Joe",
				LastName = "Smith",
				EmailAddress = "Joe@company.com"
			};

			_result = _interactor.Execute();
		}

		[Test]
		public void returns_new_profile()
		{
			Assert.AreEqual("Joe", _result.FirstName);
			Assert.AreEqual("Smith", _result.LastName);
			Assert.AreEqual("Joe@company.com", _result.EmailAddress);
		}

		[Test]
		public void id_is_greater_than_0()
		{
			Assert.That(_result.Id > 0);
		}
	}
}