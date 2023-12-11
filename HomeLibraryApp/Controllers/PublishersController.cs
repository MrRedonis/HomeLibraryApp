using HomeLibraryApp.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeLibraryApp.Controllers
{
	public class PublishersController : Controller
	{
		private readonly ILogger<PublishersController> _logger;
		private readonly IPublishersRepository _publishersRepository;

		public PublishersController(ILogger<PublishersController> logger, IPublishersRepository publishersRepository)
		{
			_logger = logger;
			_publishersRepository = publishersRepository;
		}

		public List<SelectListItem> GetPublishers()
		{
			var publishers = _publishersRepository.GetPublishers();

			return publishers.Select(publisher => new SelectListItem { Value = publisher.Id.ToString(), Text = publisher.Name }).ToList();
		}
	}
}
