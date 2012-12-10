using System.Collections.Generic;
using System.Linq;

namespace ListShifting.Tests
{
	public class ListShifter<TKey>
	{
		public List<IShiftableEntity<TKey>> ListToShift { get; set; }

		public List<IShiftableEntity<TKey>> Shift(int idToShift, int zeroIndexedNewPosition)
		{
			var thingToMove = ListToShift.FirstOrDefault(t => t.Id.Equals(idToShift));
			var shiftedList = ListToShift
				.Where(l => !l.Id.Equals(idToShift))
				.OrderBy(l => l.DisplayOrder)
				.ToList();

			if (zeroIndexedNewPosition < shiftedList.Count)
				shiftedList.Insert(zeroIndexedNewPosition, thingToMove);
			else
				shiftedList.Add(thingToMove);

			//index list to 0
			var index = 0;
			foreach (var thing in shiftedList) thing.DisplayOrder = index++;
			
			return shiftedList;
		}
	}
}