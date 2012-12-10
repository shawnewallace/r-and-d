namespace ListShifting.Tests
{
	public class TestShiftableEntity : IShiftableEntity<int>
	{
		public int Id { get; set; }
		public int DisplayOrder { get; set; }
	}
}