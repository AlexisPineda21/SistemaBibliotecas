using SistemaBibliotecas.DAL.Entites;
using SistemaBibliotecas.Domain.Interfaces;

namespace SistemaBibliotecas.Domain.Services
{
    public class ClientService : IClientService
    {
        public Task<Client> GetClientByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> RegisterClientAsync(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
