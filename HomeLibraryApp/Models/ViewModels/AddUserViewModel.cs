using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeLibraryApp.Models.ViewModels
{
	public class AddUserViewModel
	{
		[Required]
		[EmailAddress]
		[DisplayName("Adres email")]
		public string Email { get; set; }
		
		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Hasło")]
		public string Password { get; set; }

		[Required]
		[DisplayName("Rola")]
		public string Role { get; set; }

		[DisplayName("Potwierdzenie adresu email")]
		public bool ConfirmEmail { get; set; }
	}
}
