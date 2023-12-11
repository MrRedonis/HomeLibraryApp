namespace HomeLibraryApp.Models
{
    public class Position : BaseEntity
    {
        public int LibraryItemId { get; set; }
        public int Number { get; set; }
        public string Content { get; set; }
        
        public LibraryItem LibraryItem { get; set; }
    }
}
