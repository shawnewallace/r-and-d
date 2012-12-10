using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GridSpike.Lib.Model
{
	public class EntityBase<TKey> : IId<TKey>, ITimeStamped
	{
		[Key, Column("id")]
		public TKey Id { get; set; }

		[Column("when_created")]
		public DateTime? WhenCreated { get; set; }

		[Column("when_modified")]
		public DateTime? WhenModified { get; set; }
	}

	public interface ITimeStamped
	{
		DateTime? WhenCreated { get; set; }
		DateTime? WhenModified { get; set; }
	}
}