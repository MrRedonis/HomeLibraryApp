namespace HomeLibraryApp.Models
{
	public class Image : BaseEntity
	{
		public byte[] Content { get; set; }

		public ICollection<LibraryItem> LibraryItems { get; set; }
	}
}
