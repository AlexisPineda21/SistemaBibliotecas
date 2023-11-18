using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaBibliotecas.DAL;
using SistemaBibliotecas.DAL.Entites;
using SistemaBibliotecas.Domain.Interfaces;

namespace SistemaBibliotecas.Domain.Services
{
    public class BorrowingService : IBorrowingService
    {
        public readonly DataBaseContext _context;
        public BorrowingService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Borrowing> CreateBorrowingAsync(Borrowing borrowing, Guid ClientId, Guid BookId)
        {
            try
            {
                borrowing.Id = Guid.NewGuid();
                borrowing.ClientId = ClientId;
                borrowing.BookId = BookId;

                Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == BookId);

                if (book.Status == true) 
                {
                    throw new Exception("The book is already borrowed") ;
                }

                borrowing.BorrowingDate = DateTime.Now;

                borrowing.DeliveryDate = DateTime.Now.AddDays(7);

                _context.Borrowings.Add(borrowing);
                await _context.SaveChangesAsync();

                return borrowing;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<IEnumerable<Borrowing>> GetBorrowingAsync()
        {
            return await _context.Borrowings.ToListAsync();
        }

        public async Task<Borrowing> GetBorrowingByIdClientAsync(Guid ClientId)
        {
            return await _context.Borrowings.FirstOrDefaultAsync(x => x.ClientId == ClientId);
        }
    }
}
