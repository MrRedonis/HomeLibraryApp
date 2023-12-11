using HomeLibraryApp.Data;
using HomeLibraryApp.Models;
using HomeLibraryApp.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HomeLibraryApp.Repositories.Implementations
{
	public class AuthorsRepository : IAuthorsRepository
	{
		private readonly ILogger<AuthorsRepository> _logger;
		private readonly ApplicationDbContext _context;

		public AuthorsRepository(ApplicationDbContext context, ILogger<AuthorsRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public ICollection<Author> GetExistingAuthors()
		{
			return _context.Authors.ToList();
		}

		public ICollection<Author> AddAuthors(ICollection<string> authorNames)
		{
			var existingAuthors = GetExistingAuthors();
			var authors = new List<Author>();

			foreach (var authorName in authorNames)
			{
				var existingAuthor = existingAuthors.FirstOrDefault(a => a.Name == authorName);
				if (existingAuthor != null)
				{
					authors.Add(existingAuthor);
				}
				else
				{
					var author = new Author
					{
						Name = authorName
					};

					_context.Authors.Add(author);
					authors.Add(author);
				}
			}

			return authors;
		}
	}
}
