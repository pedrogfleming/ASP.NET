using BlazorCrud_EF_CodeFirst.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud_EF_CodeFirst.Data
{
    public class BookService : IBookService
    {
        /// <summary>
        /// The representation of the db
        /// </summary>
        private readonly MyBooksContext _context;
        public BookService(MyBooksContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            //If affected columns are more than 0, thats means that was a succefull delete
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Book>> GetAllBook()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookDetails(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> InsertBook(Book book)
        {
            _context.Books.Add(book);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            //We replace the book in the db with the book pass by parameter
            _context.Entry(book).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }       
        public async Task<bool> SaveBook(Book book)
        {
            if(book.Id > 0)
            {
                return await UpdateBook(book);
            }
            else
            {
                return await InsertBook(book);
            }
        }
    }
}
