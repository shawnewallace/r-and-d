using System;
using System.Collections.Generic;

namespace ConsumeSendMail.Console
{
	class Program
	{
		// this code is used for the SMTPAPI examples
		static void Main(string[] args)
		{
			var username = "CentricReview";
			var password = "00Grange";
			var from = "shawn.wallace@centricconsulting.com";
			var to = new List<String>
												 {
														 "shawn@the-wallaces.net",
														 "shawn@wshawn.com"
												 };

			//initialize the SMTPAPI example class
			var smtpapi = new Smtpapi(username, password, from, to);
			//var restapi = new WEBAPI(username, password, from, to);

			//use this section to test out our Web and SMTP examples!
			smtpapi.SimpleHTMLEmail();

			System.Console.WriteLine("Done!");
			System.Console.ReadLine();
		}

	}

}
