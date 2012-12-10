namespace DEF.Lib
{
	public enum Category
	{
		hypotension,
		desired,
		prehypertension,
		stage_1_hypertension,
		stage_2_hypertension,
		hypertensive_crisis
	}

	public class BpCategoryCalculator
	{
		public int D { get; set; }
		public int S { get; set; }

		public Category Calculate()
		{
			if (S < 90) return Category.hypotension;
			if (D < 60) return Category.hypotension;
		}
	}
}