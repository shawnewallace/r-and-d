namespace ListShifting.Tests
{
	public interface IShiftableEntity<TKey> : IId<TKey>, IShiftable { }
}