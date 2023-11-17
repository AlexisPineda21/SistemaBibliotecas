using SistemaBibliotecas.DAL.Entites;

namespace SistemaBibliotecas.Domain.Interfaces
{
    public interface IBorrowingService
    {
        Task<IEnumerable<Borrowing>> GetBorrowingAsync();
        Task<Book> GetBorrowingByIdClientAsync(Guid ClientId);
        Task<Borrowing> CreateBorrowingAsync(Borrowing borrowing, Guid ClientId, Guid BookId);

    }
}
