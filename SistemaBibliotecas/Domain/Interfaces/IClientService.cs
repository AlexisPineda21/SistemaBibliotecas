using SistemaBibliotecas.DAL.Entites;
using System.Diagnostics.Metrics;

namespace SistemaBibliotecas.Domain.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetClientByIdAsync(Guid id);

        Task<Client> RegisterClientAsync(Client client);


    }
}
