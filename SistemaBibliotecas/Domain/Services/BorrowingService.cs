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
        public async Task<Borrowing> CreateBorrowingAsync(Guid ClientId, Guid BookId)
        {
            try
            {
                Borrowing borrowing = new Borrowing();

                borrowing.Id = Guid.NewGuid();
                borrowing.ClientId = ClientId;
                borrowing.BookId = BookId;

                Book book = await _context.Books.FirstOrDefaultAsync(x => x.Id == BookId);

                Client client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == ClientId);

                if (book == null)
                {
                    throw new Exception("Book not found");
                }

                if (client == null)
                {
                    throw new Exception("Client not found");
                }

                if (book.Status == true) 
                {
                    throw new Exception("The book is already borrowed") ;
                }

                book.Status = true;

                borrowing.Book = book;

                borrowing.Client = client;

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
            return await _context.Borrowings.Include(x => x.Client).Include(x => x.Book).ToListAsync();
        }

        public async Task<Borrowing> GetBorrowingByIdClientAsync(Guid ClientId)
        {
            return await _context.Borrowings.FirstOrDefaultAsync(x => x.ClientId == ClientId);
        }
    }
}
