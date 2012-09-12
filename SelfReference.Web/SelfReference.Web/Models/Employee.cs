using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;

namespace SelfReference.Web.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }

		[Email]
		public string EmailAddress { get; set; }

		public virtual Employee Manager { get; set; }
	}
}