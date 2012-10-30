namespace FizzBuzz.Lib
{
	public class Swapper<T>
	{
		public void Execute(ref T left, ref T right)
		{
			T temp = left;
			left = right;
			right = temp;
		}
	}
}
