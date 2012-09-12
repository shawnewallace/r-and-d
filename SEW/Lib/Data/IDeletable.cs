namespace Lib.Data
{
	public interface IDeletable
	{
		bool IsDeleted { get; }
		void MarkForDeletion();
		void Undelete();
	}
}