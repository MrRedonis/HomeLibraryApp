using HomeLibraryApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomeLibraryApp.Models.ViewModels
{
    public class MediaItemViewModel
    {
        [Required]
        [MaxLength(100)]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Tytuł")]
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        [Required]
        [MaxLength(4000)]
        [Display(Name = "Opis")]
        public string Description { get; set; }
        public int Length { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Typ")]
        public LibraryItemType Type { get; set; }

        public ICollection<Position> Positions { get; set; }
        [Display(Name = "Słowa kluczowe")]
        public ICollection<Keyword> Keywords { get; set; }
    }
}
