using System;
using System.ComponentModel.DataAnnotations;
using ModelTest.Lib.Core;

namespace ModelTest.Lib.Models
{
	public class EntityBase<TKey> : IId<TKey>, ILogged
	{
		[Key] public TKey Id { get; set; }
		public DateTime? WhenCreated { get; set; }
		public DateTime? WhenLastModified { get; set; }
	}
}