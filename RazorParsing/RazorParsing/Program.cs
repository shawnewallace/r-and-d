using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RazorEngine;

namespace RazorParsing
{
	class Program
	{
		static void Main(string[] args)
		{
			var model = new { Name = "Shawn", Email="shawn@wshawn.com" };
			string template = "<html><b>@Model.Name</b>&nbsp;@Model.Email</html>";
			string message = Razor.Parse(template, model);

			Console.WriteLine(message);
			Console.ReadLine();
		}
	}
}
