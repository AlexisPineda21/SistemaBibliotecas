using Microsoft.EntityFrameworkCore;
using SistemaBibliotecas.DAL;
using SistemaBibliotecas.DAL.Entites;
using SistemaBibliotecas.Domain.Interfaces;

namespace SistemaBibliotecas.Domain.Services
{
    public class BookService : IBookService
    {
        public readonly DataBaseContext _context;
        public BookService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByTitleAsync(string title)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<Book> RegisterBookAsync(Book book)
        {
            try
            {
                book.Id = Guid.NewGuid();
                book.Status = false;


                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return book;
            }
            catch (DbUpdateException dbUpdateException)
            {
                //Captura un mensaje cuando el país ya existe
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
                //coallesense notation --> ?? (Validación de nulleables)
            }
        }
    }
}
