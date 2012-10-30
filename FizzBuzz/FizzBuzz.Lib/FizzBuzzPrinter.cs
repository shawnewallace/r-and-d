using System;

namespace FizzBuzz.Lib
{
	public class FizzBuzzPrinter
	{
		public string Calculate(int num)
		{
			if (num <= 0)
				throw new ArgumentException("Fizz Buzz only works for numbers greater than 0.");

			if (num % 3 == 0 && num % 5 == 0) return "Fizz Buzz";
			if (num % 3 == 0) return "Fizz";
			if (num % 5 == 0) return "Buzz";

			return num.ToString();
		}
	}
}