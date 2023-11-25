using SistemaBibliotecas.DAL.Entites;

namespace SistemaBibliotecas.Domain.Interfaces
{
    public interface IBorrowingService
    {
        Task<IEnumerable<Borrowing>> GetBorrowingAsync();
        Task<Borrowing> GetBorrowingByIdClientAsync(Guid ClientId);
        Task<Borrowing> CreateBorrowingAsync( Guid ClientId, Guid BookId);
        Task<Borrowing> ReturnBorrowingAsync(Guid BorrowingId);

    }
}
