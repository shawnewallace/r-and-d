using System.Data.Entity;
using Domain.Models;
using Lib.Data;

namespace Domain.Repositories
{
	public class ProductRepository : EfRepository<Product, int>
	{
		public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork) {}
	}
}