using architecture_sample.core;
using architecture_sample.data;
using architecture_sample.lib.entities;

namespace architecture_sample.lib.interactors.ProfileInteractors
{
	public class UpdateProfileInteractor
	{
		private IRepository<Profile, int> _repository;

		public UpdateProfileInteractor(IRepository<Profile, int> repository)
		{
			_repository = repository;
		}

		public void Validate(Profile profile)
		{
		}
	}
}