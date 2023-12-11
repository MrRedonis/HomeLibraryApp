using HomeLibraryApp.Data;
using HomeLibraryApp.Models;
using HomeLibraryApp.Models.ViewModels;
using HomeLibraryApp.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeLibraryApp.Repositories.Implementations
{
	public class LibraryItemsRepository : ILibraryItemsRepository
    {
        private readonly ILogger<LibraryItemsRepository> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IKeywordsRepository _keywordsRepository;
        private readonly IAuthorsRepository _authorsRepository;
        private readonly IPublishersRepository _publishersRepository;
		private readonly IAttributesRepository _attributesRepository;

        public LibraryItemsRepository(ApplicationDbContext context, 
	        ILogger<LibraryItemsRepository> logger, 
	        IKeywordsRepository keywordsRepository,
	        IAuthorsRepository authorsRepository,
	        IPublishersRepository publishersRepository,
            IAttributesRepository attributesRepository)
        {
            _context = context;
            _logger = logger;
            _keywordsRepository = keywordsRepository;
            _authorsRepository = authorsRepository;
            _publishersRepository = publishersRepository;
            _attributesRepository = attributesRepository;
        }

        public IList<LibraryItem> GetLibraryItems()
        {
            return _context.LibraryItems
                .Include(x => x.AuthorLibraryItems).ThenInclude(x => x.Author)
                .Include(x => x.PublisherLibraryItems).ThenInclude(x => x.Publisher)
                .Include(x => x.KeywordLibraryItems).ThenInclude(x => x.Keyword)
                .ToList();
        }

        public void AddLibraryItem(CreateLibraryItemViewModel model)
        {
	        byte[] fileBytes = null;

	        if (model.ImageFile is { Length: > 0 })
	        {
		        using MemoryStream ms = new MemoryStream();
		        model.ImageFile.CopyTo(ms);
		        fileBytes = ms.ToArray();
	        }

	        var image = fileBytes is { Length: > 0 } ? new Image { Content = fileBytes } : null;

	        var authors = _authorsRepository.AddAuthors(model.Authors);
	        var publishers = _publishersRepository.AddPublishers(model.Publishers);
	        var keywords = _keywordsRepository.AddKeywords(model.Keywords);

	        var attributes = _attributesRepository.GetAttributes();
	        var attributeValues = new List<AttributeValue>();
	        foreach (var attributePair in model.Attributes)
	        {
		        if (attributePair is { Key: not null, Value: not null })
		        {
			        var attribute = attributes.FirstOrDefault(x => x.Name == attributePair.Key);
			        if (attribute != null)
			        {
				        attributeValues.Add(new AttributeValue
				        {
					        Attribute = attribute,
					        Value = attributePair.Value
				        });
			        }
		        }
	        }

			var libraryItem = new LibraryItem
			{
				Title = model.Title,
				Summary = model.Summary,
				Type = model.Type,
				Image = image,
				KeywordLibraryItems = keywords.Select(x => new KeywordLibraryItem { Keyword = x }).ToList(),
				AuthorLibraryItems = authors.Select(x => new AuthorLibraryItem { Author = x }).ToList(),
				PublisherLibraryItems = publishers.Select(x => new PublisherLibraryItem { Publisher = x }).ToList(),
                Positions = model.Positions.Select(x => new Position { Number = x.Key, Content = x.Value }).ToList(),
				AttributeValues = attributeValues
			};

            _context.LibraryItems.Add(libraryItem);
            _context.SaveChanges();
		}

        public LibraryItem GetLibraryItemById(int id)
        {
			return _context.LibraryItems
				.Include(x => x.AuthorLibraryItems).ThenInclude(x => x.Author)
				.Include(x => x.PublisherLibraryItems).ThenInclude(x => x.Publisher)
				.Include(x => x.KeywordLibraryItems).ThenInclude(x => x.Keyword)
				.Include(x => x.Positions)
				.Include(x => x.Image)
                .Include(x => x.AttributeValues).ThenInclude(x => x.Attribute)
				.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateLibraryItem(EditLibraryItemViewModel model)
        {
            var existingLibraryItem = GetLibraryItemById(model.Id);

            if (existingLibraryItem != null)
            {
				byte[] fileBytes = null;

				if (model.ImageFile is { Length: > 0 })
				{
					using MemoryStream ms = new MemoryStream();
					model.ImageFile.CopyTo(ms);
					fileBytes = ms.ToArray();
				}

				var image = fileBytes is { Length: > 0 } ? new Image { Content = fileBytes } : existingLibraryItem.Image;

				var authors = _authorsRepository.AddAuthors(model.Authors);
				var publishers = _publishersRepository.AddPublishers(model.Publishers);
				var keywords = _keywordsRepository.AddKeywords(model.Keywords);

				var attributes = _attributesRepository.GetAttributes();
				var attributeValues = new List<AttributeValue>();
                foreach (var attributePair in model.Attributes)
                {
                    if (attributePair is { Key: not null, Value: not null })
                    {
                        var attribute = attributes.FirstOrDefault(x => x.Name == attributePair.Key);
                        if (attribute != null)
                        {
                            attributeValues.Add(new AttributeValue
                            {
                                Attribute = attribute,
                                Value = attributePair.Value
                            });
                        }
                    }
                }

				existingLibraryItem.Id = model.Id;
				existingLibraryItem.Title = model.Title;
				existingLibraryItem.Summary = model.Summary;
				existingLibraryItem.Image = image;
				existingLibraryItem.KeywordLibraryItems = keywords.Select(x => new KeywordLibraryItem { Keyword = x }).ToList();
				existingLibraryItem.AuthorLibraryItems = authors.Select(x => new AuthorLibraryItem { Author = x }).ToList();
				existingLibraryItem.PublisherLibraryItems = publishers.Select(x => new PublisherLibraryItem { Publisher = x }).ToList();
                existingLibraryItem.AttributeValues = attributeValues;
                existingLibraryItem.Positions = model.Positions.Select(x => new Position { Number = x.Key, Content = x.Value }).ToList();

				_context.LibraryItems.Update(existingLibraryItem);
				_context.SaveChanges();
			}
        }

        public void Delete(LibraryItem model)
        {
            _context.LibraryItems.Attach(model);
            _context.LibraryItems.Remove(model);
            _context.SaveChanges();
        }
    }
}
