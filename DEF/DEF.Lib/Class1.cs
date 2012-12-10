using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DEF.Lib
{
	public class BP
	{
		public int D { get; set; }
		public int S { get; set; }
		
		public int MAP
		{
			get
			{
				decimal val = ((2*(decimal) D) + (decimal) S)/3;
				return (int) Math.Round(val, 0);
			}
		}

		public Category Category {get { return Lib.Category.desired; }
		}
	}

	[TestFixture]
	public class MapTests
	{
		[TestCase(128, 80, 96)]
		[TestCase(132, 80, 97)]
		[TestCase(132, 80, 97)]
		[TestCase(137, 81, 100)]
		[TestCase(140, 83, 102)]
		[TestCase(122, 87, 99)]
		[TestCase(129, 79, 96)]
		[TestCase(135, 85, 102)]
		[TestCase(121, 81, 94)]
		public void calculates_properly(int s, int d, int expected)
		{
			var bp = new BP
								{
									S = s,
									D = d
								};
			Assert.AreEqual(expected, bp.MAP);
		}
	}
}
