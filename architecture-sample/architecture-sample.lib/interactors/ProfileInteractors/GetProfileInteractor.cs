using System;
using architecture_sample.core;
using architecture_sample.data;
using architecture_sample.lib.entities;

namespace architecture_sample.lib.interactors.ProfileInteractors
{
	public class GetProfileInteractor
	{
		private IRepository<Profile, int> _repository;

		public GetProfileInteractor(IRepository<Profile, int> repository)
		{
			_repository = repository;
		}

		public Profile GetById(int id)
		{
			return _repository.GetById(id);
		}
	}
}