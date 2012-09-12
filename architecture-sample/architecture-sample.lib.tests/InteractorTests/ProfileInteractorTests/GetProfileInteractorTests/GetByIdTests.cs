using architecture_sample.core;
using architecture_sample.data;
using architecture_sample.lib.entities;
using architecture_sample.lib.interactors.ProfileInteractors;
using Moq;
using NUnit.Framework;

namespace architecture_sample.lib.tests.InteractorTests.ProfileInteractorTests.GetProfileInteractorTests
{
	[TestFixture]
	public class GetByIdTests
	{
		private GetProfileInteractor _interactor;
		private Profile _result;
		private Profile _expected;

		[SetUp]
		public void SetUp()
		{
			_expected = new Profile
			{
				Id = 65,
				FirstName = "Joe",
				LastName = "Smith",
				EmailAddress = "Joe@company.com"
			};

			var repoMock = new Mock<IRepository<Profile, int>>();
			repoMock
				.Setup(m => m.GetById(65))
				.Returns(_expected);

			_interactor = new GetProfileInteractor(repoMock.Object);
		}

		[Test]
		public void using_valid_id_should_return_correct_result()
		{
			_result = _interactor.GetById(65);
			Assert.AreSame(_expected, _result);
		}

		[Test]
		public void using_an_invalid_id_should_return_null()
		{
			_result = _interactor.GetById(44);
			Assert.IsNull(_result);
		}
	}
}