using HomeLibraryApp.Enums;
using HomeLibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomeLibraryApp.Areas.Identity.Pages.Account.Manage
{
    public class StyleModel : PageModel
    {
	    [BindProperty]
	    public InputModel Input { get; set; }
	    public class InputModel
	    {
		    public Style Style { get; set; }
	    }

	    private readonly UserManager<User> _userManager;
	    private readonly SignInManager<User> _signInManager;

	    public StyleModel(
		    UserManager<User> userManager,
		    SignInManager<User> signInManager)
	    {
		    _userManager = userManager;
		    _signInManager = signInManager;
	    }
		public async Task<IActionResult> OnPostAsync()
	    {
		    if (!ModelState.IsValid)
		    {
			    return Page();
		    }

		    var user = await _userManager.GetUserAsync(User);
		    if (user == null)
		    {
			    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
		    }

		    user.Style = Input.Style;
		    await _userManager.UpdateAsync(user);
		    HttpContext.Session.SetString("UserStyle", user.Style.ToString());

			return RedirectToPage();
	    }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            Input = new InputModel
            {
                Style = user.Style
            };

            return Page();
        }
    }
}
