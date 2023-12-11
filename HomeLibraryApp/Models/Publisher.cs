namespace HomeLibraryApp.Models
{
    public class Publisher : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<PublisherLibraryItem> PublisherLibraryItems { get; set; }
    }
}
