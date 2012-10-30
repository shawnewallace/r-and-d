using System.Diagnostics.Contracts;

namespace CodeContracts.lib
{
	public class Rational
	{
		private int _numerator;
		private int _denominator;

		public Rational(int numerator, int denominator)
		{
			Contract.Requires(denominator != 0);

			_numerator = numerator;
			_denominator = denominator;
		}

		public int Denominator
		{
			get
			{
				Contract.Ensures(Contract.Result<int>() != 0);

				return _denominator;
			}
		}

		[ContractInvariantMethod]
		void ObjectInvariant()
		{
			Contract.Invariant(_denominator != 0);
		}
	}
}
