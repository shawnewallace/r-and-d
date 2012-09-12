namespace architecture_sample.core
{
	public interface ITransaction<T> : ICommand<T>
	{
		void Validate();
	}
}