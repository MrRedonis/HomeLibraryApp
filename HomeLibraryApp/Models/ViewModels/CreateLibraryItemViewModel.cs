using HomeLibraryApp.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomeLibraryApp.Models.ViewModels
{
	public class CreateLibraryItemViewModel
	{
		[Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
		public string Title { get; set; }

		public string Summary { get; set; }

		[Required(ErrorMessage = "Pole Typ jest wymagane.")]
		[Range(1, int.MaxValue, ErrorMessage = "Proszę wybrać poprawny Typ.")]
		public LibraryItemType Type { get; set; }

		[Display(Name = "Upload Image")]
		public IFormFile ImageFile { get; set; }

		public ICollection<string> Keywords { get; set; } = new List<string>();

		[Required(ErrorMessage = "At least one author is required.")]
		public ICollection<string> Authors { get; set; } = new List<string>();

		[Required(ErrorMessage = "At least one publisher is required.")]
		public ICollection<string> Publishers { get; set; } = new List<string>();

		public Dictionary<int, string> Positions { get; set; } = new Dictionary<int, string>();

		public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
	}
}
