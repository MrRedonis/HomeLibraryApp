using HomeLibraryApp.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeLibraryApp.Controllers
{
	public class AuthorsController : Controller
	{
		private readonly ILogger<AuthorsController> _logger;
		private readonly IAuthorsRepository _authorsRepository;

		public AuthorsController(ILogger<AuthorsController> logger, IAuthorsRepository authorsRepository)
		{
			_logger = logger;
			_authorsRepository = authorsRepository;
		}

		public List<SelectListItem> GetAuthors()
		{
			var authors = _authorsRepository.GetExistingAuthors();

			return authors.Select(author => new SelectListItem { Value = author.Id.ToString(), Text = author.Name }).ToList();
		}
	}
}
