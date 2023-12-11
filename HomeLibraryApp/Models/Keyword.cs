namespace HomeLibraryApp.Models
{
    public class Keyword : BaseEntity
    {
        public string Value { get; set; }
        public virtual ICollection<KeywordLibraryItem> KeywordLibraryItems { get; set; } = new List<KeywordLibraryItem>();
    }
}
