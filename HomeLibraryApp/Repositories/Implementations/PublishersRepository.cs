using HomeLibraryApp.Data;
using HomeLibraryApp.Models;
using HomeLibraryApp.Repositories.Abstractions;

namespace HomeLibraryApp.Repositories.Implementations
{
    public class PublishersRepository : IPublishersRepository	
	{
		private readonly ILogger<PublishersRepository> _logger;
		private readonly ApplicationDbContext _context;

		public PublishersRepository(ApplicationDbContext context, ILogger<PublishersRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public ICollection<Publisher> GetPublishers()
		{
			return _context.Publishers.ToList();
		}

		public ICollection<Publisher> AddPublishers(ICollection<string> publisherNames)
		{
			var existingPublishers = GetPublishers();
			var publishers = new List<Publisher>();

			foreach (var publisherName in publisherNames)
			{
				var existingPublisher = existingPublishers.FirstOrDefault(a => a.Name == publisherName);
				if (existingPublisher != null)
				{
					publishers.Add(existingPublisher);
				}
				else
				{
					var publisher = new Publisher
					{
						Name = publisherName
					};

					_context.Publishers.Add(publisher);
					publishers.Add(publisher);
				}
			}

			return publishers;
		}
	}
}
