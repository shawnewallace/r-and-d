using System;
using System.Collections.Generic;
using System.Linq;

namespace Reordering
{
	public class ThingList : List<Thing>
	{
		public int OrderIndex(string s)
		{
			var x = this.Where(t => t.Name == s).FirstOrDefault();

			if (x == null) return -1;

			return x.OrderIndex;
		}

		public void Move(string s, int i)
		{
			var itemToMove = this.Where(t => t.Name == s).FirstOrDefault();
			if (itemToMove == null) return;

			var oldIndex = itemToMove.OrderIndex;
			if (oldIndex == i) return;

			var factor = (oldIndex < i) ? -1 : 1;

			var thingsToChange = factor > 0
			                     	? this.Where(t => t.OrderIndex >= i && t.OrderIndex <= oldIndex).ToList()
			                     	: this.Where(t => t.OrderIndex <= i && t.OrderIndex >= oldIndex).ToList();

			foreach (var thing in thingsToChange)
			{
				thing.OrderIndex += factor;
			}

			itemToMove.OrderIndex = i;
		}

		public void Add(string item)
		{
			var newIndex = this.Max(t => t.OrderIndex) + 1;
			Add(new Thing(item, newIndex));
		}
	}
}