using Blazor.Shared.Models;
using Blazor.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controller
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUserServices userServices;
        public BooksController(IUserServices _userServices) 
        {
            userServices = _userServices;
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("api/get-books")]
        public async Task<IActionResult> GetBooksList()
        {
            List<Book> books = new List<Book>();

            books = userServices.GetAllStudent().ToList();
            return Ok(books);
        }

    }
}
