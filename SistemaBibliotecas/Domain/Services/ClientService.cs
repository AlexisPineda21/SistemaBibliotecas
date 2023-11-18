using Microsoft.EntityFrameworkCore;
using SistemaBibliotecas.DAL;
using SistemaBibliotecas.DAL.Entites;
using SistemaBibliotecas.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace SistemaBibliotecas.Domain.Services
{
    public class ClientService : IClientService
    {
        public readonly DataBaseContext _context;
        public ClientService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<Client> GetClientByIdAsync(Guid id)
        {
            return await _context.Clients.Include(x => x.Borrowings).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await _context.Clients.ToListAsync();

        }

        public async Task<Client> RegisterClientAsync(Client client)
        {
            try
            {
                client.Id = Guid.NewGuid();


                _context.Clients.Add(client);
                await _context.SaveChangesAsync();

                return client;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}
