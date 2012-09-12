namespace Lib
{
	public interface ICommand<T>
	{
		T Execute();
	}
}