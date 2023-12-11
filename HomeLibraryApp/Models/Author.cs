namespace HomeLibraryApp.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<AuthorLibraryItem> AuthorLibraryItems { get; set; }
    }
}
