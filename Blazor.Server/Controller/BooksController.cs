using Blazor.Shared.Models;
using Blazor.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace Blazor.Server.Controller
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookServices bookServices;
        public BooksController(IBookServices _bookServices)
        {
            bookServices = _bookServices;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("get-books")]
        public async Task<IActionResult> GetBooksList()
        {
            List<Book> books = new List<Book>();

            books = bookServices.GetAllStudent().ToList();
            return Ok(books);
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("post-book")]
        public async Task<IActionResult> AddNewBook(Book book)
        {
            try
            {
                bookServices.AddNewBook(book);
                return Ok(book);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [AllowAnonymous]
        [Route("delete-book/{bookId}")]
        public async Task<IActionResult> GetBooksList(int? bookId)
        {
            bookServices.DeleteBookById(bookId);
            return Ok();
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("update-book")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            try
            {
                bookServices.UpdateBookById(book);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


    }

}
