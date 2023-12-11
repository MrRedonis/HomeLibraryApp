using HomeLibraryApp.Models;

namespace HomeLibraryApp.Repositories.Abstractions
{
    public interface IKeywordsRepository
    {
        ICollection<Keyword> GetKeywordsByLibraryItemId(int libraryItemId);
        ICollection<Keyword> AddKeywords(ICollection<string> keywordValues);
        ICollection<Keyword> GetKeywords();
	}
}
