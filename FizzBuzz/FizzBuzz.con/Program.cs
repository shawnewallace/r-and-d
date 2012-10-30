using System;
using FizzBuzz.Lib;

namespace FizzBuzz.con
{
	class Program
	{
		static void Main(string[] args)
		{
			var printer = new FizzBuzzPrinter();

			for (var i = 1; i < 10000; i++)
				Console.WriteLine("\t" + printer.Calculate(i));

			Console.WriteLine("done");
			Console.ReadLine();
		}
	}
}
