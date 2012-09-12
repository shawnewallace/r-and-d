using Domain.Models;

namespace Domain.Boundaries
{
	public interface IProductCreator
	{
		Product GetOrCreate();
	}
}