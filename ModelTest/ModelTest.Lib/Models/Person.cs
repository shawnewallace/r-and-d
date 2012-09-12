using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using ModelTest.Lib.Core;

namespace ModelTest.Lib.Models
{
	public class Person : EntityBase<int>, INamed
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		[Email]
		public string EmailAddress { get; set; }
	}
}