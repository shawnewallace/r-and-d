using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace AWS.Signature
{
	/*
		http://webservices.amazon.com/onca/xml
	  ?Service=AWSECommerceService
	  &AWSAccessKeyId=AKIAIOSFODNN7EXAMPLE
	  &Operation=ItemLookup
	  &ItemId=0679722769&ResponseGroup=ItemAttributes,Offers,Images,Reviews&Version=2009-01-06
	 */

	public class X
	{
		
		public string Execute()
		{
			// 1) create timestamp
			var timeStamp = GenerateTimeStampString();
			// 2) URL encode the request's comma (,) and colon (:) characters, so that they don't get misinterpreted. For more information about converting to RFC 3986 specifications, see documentation and code samples for your programming language.
			// 3) Split the parameter/value pairs and delete the ampersand characters (&) so that the example looks like the following:
			// 4) Sort your parameter/value pairs by byte value (not alphabetically, lowercase parameters will be listed after uppercase ones).
			// 5) Rejoin the sorted parameter/value list with ampersands. The result is the canonical string that we'll sign:
			// 6) Prepend the following three lines (with line breaks) before the canonical string:
			// 7) The string to sign:
			// 8) Calculate an RFC 2104-compliant HMAC with the SHA256 hash algorithm using the string above with our "dummy" Secret Access Key: 1234567890. For more information about this step, see documentation and code samples for your programming language.
			// 9) URL encode the plus (+) and equal (=) characters in the signature:
			//10) Add the URL encoded signature to your request, and the result is a properly-formatted signed request:

			return string.Empty;
		}

		private string GenerateTimeStampString()
		{
			return DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ssZ");

		}
	}

	[TestFixture]
	public class signature
	{
		public const string baseUrl = "http://webservices.amazon.com/onca/xml";

		[Test]
		public void smoke_test()
		{
			var m = new X();
			m.Execute();
		}
	}

}
