using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
	public class MyClass1 : IType
	{ }

	public interface IType
	{
	}

	public class MyClass2 : IType
	{ }


	class Program
	{
		static void Main(string[] args)
		{
			var type = Type.GetType("ConsoleApplication1.MyClass1");
			Console.WriteLine(type.ToString());

			type = Type.GetType("ConsoleApplication1.MyClass2");
			Console.WriteLine(type.ToString());

			var s = new List<IType>();

			Console.ReadLine();
		}
	}
}
