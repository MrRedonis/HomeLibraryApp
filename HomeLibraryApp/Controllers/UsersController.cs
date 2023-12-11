using HomeLibraryApp.Models;
using HomeLibraryApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeLibraryApp.Controllers
{
	[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserManager<User> _userManager;

        public UsersController(ILogger<UsersController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
	        if (ModelState.IsValid)
	        {
		        var user = new User { UserName = model.Email, Email = model.Email };
		        var result = await _userManager.CreateAsync(user, model.Password);
		        if (result.Succeeded)
		        {
			        await _userManager.AddToRoleAsync(user, model.Role);
			        await _userManager.UpdateSecurityStampAsync(user);

			        if (model.ConfirmEmail)
			        {
				        var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
				        await _userManager.ConfirmEmailAsync(user, confirmationToken);
					}
					
			        TempData["SuccessMessage"] = "Użytkownik został dodany.";
					return RedirectToAction("Index");
		        }

		        TempData["ErrorMessage"] = "Użytkownik nie został dodany.";
				foreach (var error in result.Errors)
		        {
			        ModelState.AddModelError("", error.Description);
		        }
	        }
	        return View(model);
        }

        public async Task<IActionResult> Delete(string id)
        {
	        var currentUser = await _userManager.GetUserAsync(User);
			var user = await _userManager.FindByIdAsync(id);
	        if (user != null)
	        {
		        if (id == currentUser.Id)
		        {
					TempData["ErrorMessage"] = "Nie możesz usunąć własnego konta.";
					return RedirectToAction("Index");
				}

				var result = await _userManager.DeleteAsync(user);
		        if (result.Succeeded)
		        {
			        TempData["SuccessMessage"] = "Użytkownik został pomyślnie usunięty.";
			        return RedirectToAction("Index");
				}

		        TempData["ErrorMessage"] = "Użytkownik nie został pomyślnie usunięty.";
				foreach (var error in result.Errors)
		        {
			        ModelState.AddModelError("", error.Description);
		        }
	        }

	        return View("Index");
        }
	}
}
