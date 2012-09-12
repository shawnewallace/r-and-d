using System;
using System.ComponentModel.DataAnnotations;

namespace architecture_sample.lib.entities
{
	public class Profile : EntityBase<int>
	{
		[Required(ErrorMessage = "First Name is required")]
		public object FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required")]
		public object LastName { get; set; }
		
		public object EmailAddress { get; set; }
	}

}