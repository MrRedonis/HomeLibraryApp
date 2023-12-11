using HomeLibraryApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomeLibraryApp.Models
{
    public class LibraryItem : BaseEntity
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public LibraryItemType Type { get; set; }
        public int ImageId { get; set; }

        public virtual ICollection<PublisherLibraryItem> PublisherLibraryItems { get; set; } = new List<PublisherLibraryItem>();
        public virtual ICollection<AuthorLibraryItem> AuthorLibraryItems { get; set; } = new List<AuthorLibraryItem>();
        public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
        public virtual ICollection<KeywordLibraryItem> KeywordLibraryItems { get; set; } = new List<KeywordLibraryItem>();
        public virtual ICollection<AttributeValue> AttributeValues { get; set; } = new List<AttributeValue>();
        public virtual Image Image { get; set; }
    }
}
