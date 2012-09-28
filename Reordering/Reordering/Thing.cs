using System;
using System.Web;

namespace Reordering
{
	public class Thing
	{
		public Thing(string s, int i)
		{
			Name = s;
			OrderIndex = i;
		}

		public string Name { get; set; }
		public int OrderIndex { get; set; }
	}
}