
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace DiplomaProjects.Library
{
    public class Library
    {
        private readonly List<Book> _books = new();
        private readonly ILogger<Library> _logger;

        public Library(ILogger<Library> logger)
        {
            _logger = logger;
        }

        public void AddBook(Book book) => _books.Add(book);

        public bool RemoveBook(string isbn)
        {
            var book = _books.FirstOrDefault(b => b.ISBN == isbn);
            if (book != null)
            {
                _books.Remove(book);
                return true;
            }
            return false;
        }

        public Book FindByTitle(string title)
        {
            return _books.FirstOrDefault(
                b => string.Equals(b.bookTitle, title, StringComparison.OrdinalIgnoreCase)
            ) ?? new Book("Unknown", "Unknown", "Unknown");
        }


        public void DisplayLibraryStorage()
        {
            foreach (var book in _books)
                _logger.LogInformation(book.ToString());
        }

        public List<Book> GetBooks() => _books;
    }
}
