using BlazorCrud_EF_CodeFirst.Model;

namespace BlazorCrud_EF_CodeFirst.Data
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBook();
        Task<Book> GetBookDetails(int id);
        Task<bool> InsertBook(Book book);
        Task<bool> UpdateBook(Book book);
        Task<bool>DeleteBook(int id);
        /// <summary>
        /// The service must be responsable to know where you whant to update or insert a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        Task<bool> SaveBook(Book book);
    }
}
