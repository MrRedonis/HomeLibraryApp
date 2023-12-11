using HomeLibraryApp.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace HomeLibraryApp.Controllers
{
	public class KeywordsController : Controller
	{
		private readonly ILogger<KeywordsController> _logger;
		private readonly IKeywordsRepository _keywordsRepository;

		public KeywordsController(ILogger<KeywordsController> logger, IKeywordsRepository keywordsRepository)
		{
			_logger = logger;
			_keywordsRepository = keywordsRepository;
		}

		public List<SelectListItem> GetKeywords()
		{
			var keywords = _keywordsRepository.GetKeywords();

			return keywords.Select(keyword => new SelectListItem { Value = keyword.Id.ToString(), Text = keyword.Value }).ToList();
		}
	}
}
