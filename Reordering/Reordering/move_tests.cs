using NUnit.Framework;

namespace Reordering
{
	[TestFixture]
	public class move_tests
	{
		private ThingList _list;

		[SetUp]
		public void SetUp()
		{
			_list = new ThingList
			        	{
			        		new Thing("A", 0),
			        		new Thing("B", 1),
			        		new Thing("C", 2),
			        		new Thing("D", 3),
			        	};
		}

		[Test]
		public void name_does_not_exist()
		{
			_list.Move("Z", 1);

			Assert.AreEqual(4, _list.Count);

			Assert.AreEqual(0, _list.OrderIndex("A"));
			Assert.AreEqual(1, _list.OrderIndex("B"));
			Assert.AreEqual(2, _list.OrderIndex("C"));
			Assert.AreEqual(3, _list.OrderIndex("D"));
		}

		[Test]
		public void moving_first_down_one_spot()
		{
			_list.Move("A", 1);

			Assert.AreEqual(4, _list.Count);

			Assert.AreEqual(1, _list.OrderIndex("A"));
			Assert.AreEqual(0, _list.OrderIndex("B"));
			Assert.AreEqual(2, _list.OrderIndex("C"));
			Assert.AreEqual(3, _list.OrderIndex("D"));
		}

		[Test]
		public void moving_first_to_last()
		{
			_list.Move("A", 3);

			Assert.AreEqual(4, _list.Count);

			Assert.AreEqual(3, _list.OrderIndex("A"));
			Assert.AreEqual(0, _list.OrderIndex("B"));
			Assert.AreEqual(1, _list.OrderIndex("C"));
			Assert.AreEqual(2, _list.OrderIndex("D"));
		}

		[Test]
		public void moving_last_to_first()
		{
			_list.Move("D", 0);

			Assert.AreEqual(4, _list.Count);

			Assert.AreEqual(1, _list.OrderIndex("A"));
			Assert.AreEqual(2, _list.OrderIndex("B"));
			Assert.AreEqual(3, _list.OrderIndex("C"));
			Assert.AreEqual(0, _list.OrderIndex("D"));
		}

		[Test]
		public void moving_last_to_middle()
		{
			_list.Move("D", 2);

			Assert.AreEqual(4, _list.Count);

			Assert.AreEqual(0, _list.OrderIndex("A"));
			Assert.AreEqual(1, _list.OrderIndex("B"));
			Assert.AreEqual(3, _list.OrderIndex("C"));
			Assert.AreEqual(2, _list.OrderIndex("D"));
		}

		[Test]
		public void moving_middle_to_first()
		{
			_list.Move("C", 0);

			Assert.AreEqual(4, _list.Count);

			Assert.AreEqual(1, _list.OrderIndex("A"));
			Assert.AreEqual(2, _list.OrderIndex("B"));
			Assert.AreEqual(0, _list.OrderIndex("C"));
			Assert.AreEqual(3, _list.OrderIndex("D"));
		}

		[Test]
		public void moving_up_one_spot()
		{
			_list.Move("C", 1);

			Assert.AreEqual(4, _list.Count);

			Assert.AreEqual(0, _list.OrderIndex("A"));
			Assert.AreEqual(2, _list.OrderIndex("B"));
			Assert.AreEqual(1, _list.OrderIndex("C"));
			Assert.AreEqual(3, _list.OrderIndex("D"));
		}
	}
}