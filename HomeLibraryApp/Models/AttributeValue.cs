namespace HomeLibraryApp.Models
{
	public class AttributeValue : BaseEntity
	{
		public string Value { get; set; }
		public int AttributeId { get; set; }
		public Attribute Attribute { get; set; }
		public int LibraryItemId { get; set; }
		public LibraryItem LibraryItem { get; set; }
	}
}
