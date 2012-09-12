using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace architecture_sample.core
{
	public interface IValidator
	{
		ICollection<ValidationResult> ErrorCollection { get; }
		bool TryValidate(object @object);
	}
}