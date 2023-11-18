using Microsoft.AspNetCore.Mvc;
using SistemaBibliotecas.DAL.Entites;
using SistemaBibliotecas.Domain.Interfaces;
using System.Diagnostics.Metrics;

namespace SistemaBibliotecas.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")] 
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksAsync()
        {
            var books = await _bookService.GetBooksAsync(); 

            if (books == null || !books.Any())
            {
                return NotFound();
            }

            return Ok(books); 
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByName/{name}")] 
        public async Task<ActionResult<Book>> GetBookByTitleAsync(string name)
        {
            if (name == null) return BadRequest("Book's title is required!");

            var book = await _bookService.GetBookByTitleAsync(name);

            if (book == null) return NotFound(); 

            return Ok(book); 
        }


        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateCountryAsync(Book book)
        {
            try
            {
                var createdBook = await _bookService.RegisterBookAsync(book);

                if (createdBook == null)
                {
                    return NotFound(); 
                }

                return Ok(createdBook); 
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(String.Format("The book {0} already exists.", book.Title)); 
                }

                return Conflict(ex.Message);
            }
        }

    }
}
