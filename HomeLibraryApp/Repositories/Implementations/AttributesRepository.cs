using HomeLibraryApp.Data;
using HomeLibraryApp.Repositories.Abstractions;

namespace HomeLibraryApp.Repositories.Implementations
{
	public class AttributesRepository : IAttributesRepository
	{
		private readonly ILogger<AttributesRepository> _logger;
		private readonly ApplicationDbContext _context;

		public AttributesRepository(ApplicationDbContext context, ILogger<AttributesRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public Dictionary<string, string> GetAttributesDictionary()
		{
			var attributes =_context.Attributes.ToList();
			var dictionary = new Dictionary<string, string>();
			foreach (var attribute in attributes)
			{
				dictionary.Add(attribute.Name, string.Empty);
			}

			return dictionary;
		}

        public ICollection<Models.Attribute> GetAttributes()
        {
            return _context.Attributes.ToList();
        }
    }
}
