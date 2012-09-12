namespace architecture_sample.core
{
	public interface IDeletable
	{
		bool IsDeleted { get; }
		void MarkForDeletion();
		void Undelete();
	}
}