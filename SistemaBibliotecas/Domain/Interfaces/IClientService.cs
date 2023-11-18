using SistemaBibliotecas.DAL.Entites;
using System.Diagnostics.Metrics;

namespace SistemaBibliotecas.Domain.Interfaces
{
    public interface IClientService
    {

        Task<IEnumerable<Client>> GetClientsAsync();

        Task<Client> GetClientByIdAsync(Guid id);

        Task<Client> RegisterClientAsync(Client client);


    }
}
