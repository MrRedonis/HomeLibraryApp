namespace HomeLibraryApp.Models
{
    public class KeywordLibraryItem : BaseEntity
    {
        public int KeywordId { get; set; }
        public Keyword Keyword { get; set; }
        public int LibraryItemId { get; set; }
        public LibraryItem LibraryItem { get; set; }
    }
}
