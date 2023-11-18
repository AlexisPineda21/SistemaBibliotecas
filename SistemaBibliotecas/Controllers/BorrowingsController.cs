using Microsoft.AspNetCore.Mvc;
using SistemaBibliotecas.DAL.Entites;
using SistemaBibliotecas.Domain.Interfaces;
using SistemaBibliotecas.Domain.Services;

namespace SistemaBibliotecas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BorrowingsController : Controller
    {
        private readonly IBorrowingService _borrowingService;
        public BorrowingsController(IBorrowingService borrowingService)
        {
            _borrowingService = borrowingService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Borrowing>>> GetBorrowingAsync()
        {
            var borrowings = await _borrowingService.GetBorrowingAsync();

            if (borrowings == null || !borrowings.Any())
            {
                return NotFound();
            }

            return Ok(borrowings);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByClientId/{id}")]
        public async Task<ActionResult<IEnumerable<Borrowing>>> GetBorrowingByIdClientAsync(Guid id)
        {
            if (id == null) return BadRequest("Client id is required!");

            var client = await _borrowingService.GetBorrowingByIdClientAsync(id);

            if (client == null) return NotFound();

            return Ok(client);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateBorrowingAsync( Guid clientId, Guid bookId)
        {
            try
            {
                var createdBorrowing = await _borrowingService.CreateBorrowingAsync(clientId, bookId);

                if (createdBorrowing == null) return NotFound();

                return Ok(createdBorrowing);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("The borrowing {0} already exists."));
                }

                return Conflict(ex.Message);
            }
        }
    }
}
