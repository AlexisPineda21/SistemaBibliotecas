using System.Diagnostics.Metrics;
using static System.Reflection.Metadata.BlobBuilder;

namespace SistemaBibliotecas.DAL.Entites
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }


        public async Task SeederAsync()
        {

            await _context.Database.EnsureCreatedAsync();

            await PopulateClientsAsync();

            await PopulateBooksAsync();

            await _context.SaveChangesAsync(); 
        }

        #region Private Methods
        private async Task PopulateClientsAsync()
        {

            if (!_context.Clients.Any())
            {

                _context.Clients.Add(new Client
                {
                    Email = "juan@hotmail.com",
                    Name = "Juan A",
                    Password = "juan1234",
                    
                });

                _context.Clients.Add(new Client
                {
                    Email = "alexis@gmail.com",
                    Name = "Alexis P",
                    Password = "alexis1234",

                });

                _context.Clients.Add(new Client
                {
                    Email = "kevin@hotmail.com",
                    Name = "Kevin M",
                    Password = "kevin1234",

                });
            }
        }

        private async Task PopulateBooksAsync()
        {

            if (!_context.Books.Any())
            {

                _context.Books.Add(new Book
                {
                    Title = "Cien años de Soledad",
                    Autor = "Gabriel Garcia Marquez",
                    Status = false,

                });

                _context.Books.Add(new Book
                {
                    Title = "El olvido que seremos",
                    Autor = "Héctor Abad",
                    Status = false,

                });

                _context.Books.Add(new Book
                {
                    Title = "Que viva la música",
                    Autor = "Andrés Caicedo",
                    Status = false,

                });
            }
        }
    }

    #endregion
}
