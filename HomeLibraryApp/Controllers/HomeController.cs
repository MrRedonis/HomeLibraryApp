using HomeLibraryApp.Enums;
using HomeLibraryApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
	        if (HttpContext.Session.GetString("UserStyle") == null && HttpContext.User.Identity.IsAuthenticated)
	        {
		        var user = await _userManager.GetUserAsync(User);
		        HttpContext.Session.SetString("UserStyle", user.Style.ToString());
			}
			
			return View();
		}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public void ToDark()
        {
            ViewBag.UserStyle = 2;
        }

        [HttpGet]
        public void ToLight()
        {
            ViewBag.UserStyle = 1;
        }
    }
}
