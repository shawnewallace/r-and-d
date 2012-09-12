using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelTest.Lib.DataAnnotations;

namespace ModelTest.Lib.Models
{
	[Table("attendees")]
	public class Attendee : Person
	{
		[Required]
		[PhoneNumber]
		[DisplayName("Mobile Number")]
		public string MobileNumber { get; set; }

		public virtual ICollection<Event> AttendedEvents { get; set; }
	}
}