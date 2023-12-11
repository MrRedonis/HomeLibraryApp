using HomeLibraryApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomeLibraryApp.Models.ViewModels
{
    public class EditLibraryItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Summary is required.")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Type is required.")]
        public LibraryItemType Type { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile? ImageFile { get; set; }

        public ICollection<string> Keywords { get; set; } = new List<string>();

        [Required(ErrorMessage = "At least one author is required.")]
        public ICollection<string> Authors { get; set; } = new List<string>();

        [Required(ErrorMessage = "At least one publisher is required.")]
        public ICollection<string> Publishers { get; set; } = new List<string>();

        public Dictionary<int, string> Positions { get; set; } = new Dictionary<int, string>();

        public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
	}
}
