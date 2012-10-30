using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeContracts.lib;

namespace CodeContracts.console
{
	class Program
	{
		static void Main(string[] args)
		{
			var x = new Rational(5, 0);

			Console.WriteLine(x.Denominator);

			Console.ReadLine();
		}
	}
}
