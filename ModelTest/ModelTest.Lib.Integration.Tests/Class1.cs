using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModelTest.Lib.Data;
using ModelTest.Lib.Models;
using NUnit.Framework;

namespace ModelTest.Lib.Integration.Tests
{
	[TestFixture]
	public class Class1
	{
		[Test]
		public void smoke_test()
		{
			using (var db = new ModelTestContext())
			{
				db.Attendees.Add(new Attendee
				{
				  EmailAddress = "attendee@mycompany.com",
				  FirstName = "first",
				  LastName = "last",
				  MobileNumber = "6142701600",
				  WhenCreated = DateTime.Now,
				  WhenLastModified = DateTime.Now
				});

				db.Users.Add(new User
				{
					EmailAddress = "user@yourcompany.com",
					FirstName = "first-user",
					LastName = "last-user",
					WhenCreated = DateTime.Now,
					WhenLastModified = DateTime.Now
				});

				db.SaveChanges();
			}
		}

	}
}
