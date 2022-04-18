using my_book.Data.Models;
using my_book.Data.ViewModels;

namespace my_book.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            this._context = context;
        }

        public void AddBook(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description=book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead? book.DateRead.Value:null,
                Rate = book.IsRead ? book.Rate.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                Author = book.Author,
                DateAdded = DateTime.Now,
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(x => x.Id == bookId);
        }
        public Book UpdateBookById(int bookId, BookVM book)
        {
            var bookFetched = _context.Books.FirstOrDefault(x => x.Id==bookId);
            if(bookFetched != null)
            {
                bookFetched.Title = book.Title;
                bookFetched.Description = book.Description;
                bookFetched.IsRead = book.IsRead;
                bookFetched.DateRead = book.IsRead ? book.DateRead.Value : null;
                bookFetched.Rate = book.IsRead ? book.Rate.Value : null;
                bookFetched.Genre = book.Genre;
                bookFetched.CoverUrl = book.CoverUrl;
                bookFetched.Author = book.Author;

                _context.SaveChanges();
            }
            return bookFetched;
        }
        public void DeleteBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                _context.Books.Remove(book);
            }
        }
    }
}   
