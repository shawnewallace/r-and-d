namespace architecture_sample.core
{
	public interface IEntity<TKey> : IDeletable
	{
		TKey Id { get; set; }
		bool IsTransient { get; }
	}
}