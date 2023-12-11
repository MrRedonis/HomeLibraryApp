using HomeLibraryApp.Models;

namespace HomeLibraryApp.Repositories.Abstractions
{
	public interface IPublishersRepository
	{
		ICollection<Publisher> AddPublishers(ICollection<string> publisherNames);
		ICollection<Publisher> GetPublishers();
	}
}
