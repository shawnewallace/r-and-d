using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GridSpike.Lib.Model
{
	[Table("queued_tests")]
	public class QueuedTest : EntityBase<int>
	{
		[Column("feature_name")]
		public string Feature { get; set; }

		[Column("scenario_title")]
		public string Scenario { get; set; }

		[Column("target_environment")]
		public string TargetEnvironment { get; set; }

		[Column("selected_on")]
		public DateTime? SelectedOn { get; set; }

		[Column("selected_by")]
		public string SelectedBy { get; set; }

		[Column("completed_on")]
		public DateTime? CompletedOn { get; set; }
	}
}