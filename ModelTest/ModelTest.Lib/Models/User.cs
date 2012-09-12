using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelTest.Lib.Models
{
	[Table("users")]
	public class User : Person
	{
		public string UserName { get; set; }
		public virtual ICollection<Event> OrganizedEvents { get; set; }
	}
}