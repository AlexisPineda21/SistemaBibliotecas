using SistemaBibliotecas.DAL.Entites;

namespace SistemaBibliotecas.Domain.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBookAsync();
        Task<Book> GetBookByTitleAsync(string title);
        Task<Book> RegisterBookAsync(Book book);


    }
}
