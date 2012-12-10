namespace GridSpike.Lib.Model
{
	public interface IId<TKey>
	{
		TKey Id { get; set; }
	}
}