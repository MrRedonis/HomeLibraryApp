using HomeLibraryApp.Models;

namespace HomeLibraryApp.Repositories.Abstractions
{
	public interface IAuthorsRepository
	{
		ICollection<Author> GetExistingAuthors();
		ICollection<Author> AddAuthors(ICollection<string> authorNames);
	}
}
