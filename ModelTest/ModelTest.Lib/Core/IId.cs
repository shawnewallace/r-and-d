namespace ModelTest.Lib.Core
{
	public interface IId<TKey>
	{
		TKey Id { get; set; }
	}
}