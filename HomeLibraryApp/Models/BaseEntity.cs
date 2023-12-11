using System.ComponentModel.DataAnnotations;

namespace HomeLibraryApp.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required] public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
