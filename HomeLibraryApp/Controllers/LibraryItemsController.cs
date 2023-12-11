using HomeLibraryApp.Enums;
using HomeLibraryApp.Models.ViewModels;
using HomeLibraryApp.Repositories.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace HomeLibraryApp.Controllers
{
    [Authorize]
	public class LibraryItemsController : Controller
    {
        private readonly ILogger<LibraryItemsController> _logger;
        private readonly ILibraryItemsRepository _libraryItemsRepository;
        private readonly IAttributesRepository _attributesRepository;


		public LibraryItemsController(
	        ILogger<LibraryItemsController> logger, 
	        ILibraryItemsRepository libraryItemsRepository,
	        IAttributesRepository attributesRepository)
        {
            _logger = logger;
            _libraryItemsRepository = libraryItemsRepository;
            _attributesRepository = attributesRepository;
        }

        [HttpGet]
		public IActionResult Index()
        {
            var mediaItems = _libraryItemsRepository.GetLibraryItems();

			return View(mediaItems);
		}

		public List<SelectListItem> GetTypes()
		{
			var enumValues = Enum.GetValues(typeof(LibraryItemType)).Cast<LibraryItemType>();

			var selectList = new List<SelectListItem>();

			foreach (var enumValue in enumValues)
			{
				selectList.Add(new SelectListItem
				{
					Value = ((int)enumValue).ToString(),
					Text = Enum.GetName(typeof(LibraryItemType), enumValue)
				});
			}
            return selectList;
		}

		public IActionResult Details(int id)
        {
			var mediaItem = _libraryItemsRepository.GetLibraryItemById(id);

			return View(mediaItem);
		}

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
			var viewModel = new CreateLibraryItemViewModel
			{
				Attributes = _attributesRepository.GetAttributesDictionary()
			};


			return View(viewModel);
		}

		[HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(CreateLibraryItemViewModel model)
        {
	        if (!ModelState.IsValid) return View(model);

			_libraryItemsRepository.AddLibraryItem(model);

			return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var libraryItem = _libraryItemsRepository.GetLibraryItemById(id);

            var positionsDictionary = new Dictionary<int, string>();
            foreach (var position in libraryItem.Positions)
            {
				positionsDictionary.Add(position.Number, position.Content);
			}

            var attributesDictionary = _attributesRepository.GetAttributesDictionary();
            foreach (var attribute in libraryItem.AttributeValues)
            {
                attributesDictionary[attribute.Attribute.Name] = attribute.Value;
			}

			var editModel = new EditLibraryItemViewModel()
            {
                Id = libraryItem.Id,
                Title = libraryItem.Title,
                Summary = libraryItem.Summary,
                Type = libraryItem.Type,
                Keywords = libraryItem.KeywordLibraryItems.Select(x => x.Keyword.Value).ToList(),
				Authors = libraryItem.AuthorLibraryItems.Select(x => x.Author.Name).ToList(),
                Publishers = libraryItem.PublisherLibraryItems.Select(x => x.Publisher.Name).ToList(),
                Positions = positionsDictionary,
                Attributes = attributesDictionary
			};

            return View(editModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(EditLibraryItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                _libraryItemsRepository.UpdateLibraryItem(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
		public IActionResult Delete(int id)
        {
            var libraryItem = _libraryItemsRepository.GetLibraryItemById(id);
            if (libraryItem == null)
            {
                return NotFound();
            }

            _libraryItemsRepository.Delete(libraryItem);

            return RedirectToAction("Index");
        }
    }
}
