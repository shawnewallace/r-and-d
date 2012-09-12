using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Lib.Data;

namespace Domain.Interactors
{
	public class GetProductInteractor
	{
		private IRepository<Product, int> _repository;

		public GetProductInteractor(IRepository<Product, int> repository)
		{
			_repository = repository;
		}

		public Product GetById(int id)
		{
			return _repository.GetById(id);
		}

		public Product GetByName(string name)
		{
			return _repository
				.Where(p => p.Name.ToLower() == name.ToLower())
				.FirstOrDefault();
		}
	}
}
