using System;
using Domain.Models;
using Lib;

namespace Domain.Interactors
{
	public class CreateProductInteractor : ICommand<Product>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		
		public Product Execute()
		{
			return new Product
			       	{
			       		Name = Name,
								Price = Price
			       	};
		}
	}
}