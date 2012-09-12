using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelTest.Lib.Models
{
	[Table("events")]
	public class Event : EntityBase<int>
	{
		public string Name { get; set; }
		public User Organizer { get; set; }
		public virtual ICollection<Attendee> Attendees { get; set; }
	}
}
