using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using architecture_sample.core;
using architecture_sample.data;
using architecture_sample.lib.entities;

namespace architecture_sample.lib.interactors.ProfileInteractors
{
	public class AddProfileInteractor : ICommand<Profile>
	{
		private IRepository<Profile, int> _repository;
		private IValidator _validator;
		protected ICollection<ValidationResult> ErrorMessages { get; private set; }

		public AddProfileInteractor(IRepository<Profile, int> repository, IValidator validator)
		{
			_repository = repository;
			_validator = validator;
		}

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }

		public Profile Execute()
		{
			var newProfile = new Profile
			       	{
			       		FirstName = FirstName,
								LastName = LastName,
								EmailAddress = EmailAddress
			       	};

			if (!_validator.TryValidate(newProfile))
			{
				ErrorMessages = _validator.ErrorCollection;
				return null;
			}

			return _repository.Add(newProfile);
		}
	}
}