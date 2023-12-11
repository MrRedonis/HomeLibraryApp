using System.ComponentModel.DataAnnotations;

namespace HomeLibraryApp.Enums
{
	public enum Style
	{
		[Display(Name = "Jasny")]
		Bright = 1,
		[Display(Name = "Ciemny")]
		Dark = 2
	}
}
