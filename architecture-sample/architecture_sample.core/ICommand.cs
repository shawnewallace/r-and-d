namespace architecture_sample.core
{
	public interface ICommand<T>
	{
		T Execute();
	}
}