namespace Lib.Data
{
	public interface IEntity<TKey> : IDeletable
	{
		TKey Id { get; set; }
		bool IsTransient { get; }
	}
}