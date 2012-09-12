using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using PhoneNumbers;

namespace ModelTest.Lib.DataAnnotations
{
	public class PhoneNumberAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var valueString = value as string;

			if (string.IsNullOrEmpty(valueString)) return true;

			var util = PhoneNumberUtil.GetInstance();
			try
			{
				var number = util.Parse(valueString, "US");
				return util.IsValidNumber(number);
			}
			catch (NumberParseException)
			{
				return false;
			}
		}
	}
}
