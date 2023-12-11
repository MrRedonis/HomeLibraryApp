using HomeLibraryApp.Data;
using HomeLibraryApp.Models;
using HomeLibraryApp.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeLibraryApp.Repositories.Implementations
{
    public class KeywordsRepository : IKeywordsRepository
    {
        private readonly ILogger<KeywordsRepository> _logger;
        private readonly ApplicationDbContext _context;

        public KeywordsRepository(ApplicationDbContext context, ILogger<KeywordsRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public ICollection<Keyword> GetKeywordsByLibraryItemId(int libraryItemId)
        {
            return _context.KeywordLibraryItems
                .Include(x => x.Keyword)
                .Where(x => x.LibraryItemId == libraryItemId)
                .Select(x => x.Keyword)
                .ToList();
        }

        public ICollection<Keyword> GetKeywords()
        {
			return _context.Keywords.ToList();
		}

        public ICollection<Keyword> AddKeywords(ICollection<string> keywordValues)
        {
			var existingKeywords = GetKeywords();
			var keywords = new List<Keyword>();

			foreach (var keywordValue in keywordValues)
			{
				var existingKeyword = existingKeywords.FirstOrDefault(a => a.Value == keywordValue);
				if (existingKeyword != null)
				{
					keywords.Add(existingKeyword);
				}
				else
				{
					var keyword = new Keyword
					{
						Value = keywordValue
					};

					_context.Keywords.Add(keyword);
					keywords.Add(keyword);
				}
			}

			return keywords;
		}

        public Keyword GetKeywordByName(string name)
        {
            return _context.Keywords.FirstOrDefault(k => k.Value == name);
        }
    }
}
