namespace ListShifting.Tests
{
	public interface IId<TKey>
	{
		TKey Id { get; set; }
	}
}