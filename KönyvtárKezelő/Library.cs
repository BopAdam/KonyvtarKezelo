using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KönyvtárKezelő
{
    public class Library
    {
        private readonly List<Book> _books = new List<Book>();
        private readonly List<Member> _members = new List<Member>();

        public IReadOnlyList<Book> Books => _books;
        public IReadOnlyList<Member> Members => _members;

        public void AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (_books.Any(b => b.ISBN == book.ISBN)) throw new InvalidOperationException("Már létezik ilyen ISBN-mel könyv.");
            _books.Add(book);
        }

        public void RemoveBook(string isbn)
        {
            var book = FindBook(isbn);
            if (book == null) throw new InvalidOperationException("A megadott ISBN-hez nincs könyv.");
            if (!book.IsAvailable) throw new InvalidOperationException("A könyv jelenleg ki van kölcsönözve, nem törölhető.");

            _books.Remove(book);
        }

        public Book FindBook(string isbn) => _books.FirstOrDefault(b => b.ISBN == isbn);

        public IEnumerable<Book> ListAvailableBooks(Func<Book, bool> filter = null)
        {
            var query = _books.Where(b => b.IsAvailable);
            if (filter != null) query = query.Where(filter);
            return query.OrderBy(b => b.Title).ToList();
        }
    }
}
