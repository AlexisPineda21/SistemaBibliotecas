using Microsoft.AspNetCore.Mvc;
using SistemaBibliotecas.DAL.Entites;
using SistemaBibliotecas.Domain.Interfaces;
using SistemaBibliotecas.Domain.Services;

namespace SistemaBibliotecas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : Controller
    {

        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }


        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClientsAsync()
        {
            var client = await _clientService.GetClientsAsync();

            if (client == null || !client.Any())
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] 
        public async Task<ActionResult<Client>> GetClientByIdAsync(Guid id)
        {
            if (id == null) return BadRequest("Client id is required!");

            var client = await _clientService.GetClientByIdAsync(id);

            if (client == null) return NotFound();

            return Ok(client);
        }


        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> RegisterClientAsync(Client client)
        {
            try
            {
                var createdClient = await _clientService.RegisterClientAsync(client);

                if (createdClient == null)
                {
                    return NotFound();
                }

                return Ok(createdClient);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("The client {0} already exists.", client.Email));
                }

                return Conflict(ex.Message);
            }
        }
    }
}
