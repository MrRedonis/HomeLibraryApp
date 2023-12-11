using HomeLibraryApp.Enums;
using Microsoft.AspNetCore.Identity;

namespace HomeLibraryApp.Models
{
	public class User : IdentityUser
	{
		public Style Style { get; set; } = Style.Bright;
		
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
