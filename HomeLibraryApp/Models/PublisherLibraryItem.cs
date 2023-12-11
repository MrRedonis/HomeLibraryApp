namespace HomeLibraryApp.Models
{
    public class PublisherLibraryItem : BaseEntity
    {
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public int LibraryItemId { get; set; }
        public LibraryItem LibraryItem { get; set; }
    }
}
