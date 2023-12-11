namespace HomeLibraryApp.Models
{
    public class AuthorLibraryItem : BaseEntity
    {
        public int LibraryItemId { get; set; }
        public LibraryItem LibraryItem { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
