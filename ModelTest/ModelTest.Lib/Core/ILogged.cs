using System;

namespace ModelTest.Lib.Core
{
	public interface ILogged
	{
		DateTime? WhenCreated { get; set; }
		DateTime? WhenLastModified { get; set; }
	}
}