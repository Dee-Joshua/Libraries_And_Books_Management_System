using LABMS.Application.DTOs.ForCreation;
using LABMS.Controller.ActionFilters;
using LABMS.ServiceContract.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LABMS.Controller.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public BooksController(IServiceManager service)
        {
            serviceManager = service;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await serviceManager.BookService.GetAllBooksAsync(false);
            return Ok(books);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<ActionResult> GetBookById( int id)
        {
            if (id.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            }
            var book = await serviceManager.BookService.GetBooksById(id, false);
            return Ok(book);
        }

        // POST api/<MembersController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> AddBook([FromBody] BookForCreationDto bookForCreation)
        {
            var bookCreated = await serviceManager.BookService.CreateBook(bookForCreation);
            return CreatedAtAction(nameof(GetBookById), new { id = bookCreated.Isbn }, bookCreated);
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            if (id.Equals(0))
            {
                return BadRequest("Id's cannot be 0");
            }
            await serviceManager.BookService.DeleteBook(id);
            return NoContent();
        }


        //More complex operations on book are below

        [HttpGet("author/{authorId}")]
        public async Task<ActionResult> GetAllBooksByAuthor(int authorId)
        {
            if (authorId.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            }
            var books = await serviceManager.BookService.GetAllBookByAuthorAsync(authorId, false);
            return Ok(books);
        }

        [HttpGet("requests")]
        public async Task<ActionResult> GetAllBooksRequested()
        {
            var books = await serviceManager.BookService.GetAllBooksRequested(false);
            return Ok(books);
        }
        [HttpGet("requests/library/{libraryId}")]
        public async Task<ActionResult> GetAllBooksRequestedByLibrary(int libraryId)
        {
            if (libraryId.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            }
            var books = await serviceManager.BookService.GetAllBooksRequestedByLibraryId(libraryId, false);
            return Ok(books);
        }
        [HttpGet("requests/member/{memberId}")]
        public async Task<ActionResult> GetAllBooksRequestedByMember(int memberId)
        {
            if (memberId.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            }
            var books = await serviceManager.BookService.GetAllBooksRequestedByMemberId(memberId, false);
            return Ok(books);
        }
    }
}
