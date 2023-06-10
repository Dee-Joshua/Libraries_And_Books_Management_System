using LABMS.Application.DTOs.ForCreation;
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
    [Route("api/authors/{authorId}/books")]
    [ApiController]
    public class BookByAuthorController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public BookByAuthorController(IServiceManager service)
        {
            serviceManager = service;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult> GetAllBooksByAuthor(int authorId)
        {
            if (authorId.Equals(0))
            {
                return BadRequest("member id cannot be 0");
            }
            var books = await serviceManager.BookByAuthorService.GetAllBooks_By_AuthorByAuthorIdAsync(authorId, false);
            return Ok(books);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}", Name = "GetBooksByAuthorById")]
        public async Task<ActionResult> GetBooksByAuthorById(int authorId, int id)
        {
            if (id.Equals(0) || authorId.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            }
            var book = await serviceManager.BookByAuthorService.GetAllBooks_By_AuthorByAuthorBookIdIdAsync(authorId, id, false);
            return Ok(book);
        }

        // POST api/<MembersController>
        [HttpPost]
        public async Task<ActionResult> AddBookByAuthor(int authorId, [FromBody] Books_By_AuthorForCreation books_By_Author)
        {
            if (books_By_Author == null)
            {
                return BadRequest("Input cannot be null");
            }
            if (books_By_Author.AuthorId != authorId)
            {
                return BadRequest("Wrong user Id inputed");
            }
            var bookByAuthorCreated = await serviceManager.BookByAuthorService.CreateBook_By_Author(books_By_Author);
            return CreatedAtAction(nameof(GetBooksByAuthorById), new { authorId, id = bookByAuthorCreated.Isbn }, bookByAuthorCreated);
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookByAuthor(int authorId, int id)
        {
            if (id.Equals(0) || authorId.Equals(0))
            {
                return BadRequest("Id's cannot be 0");
            }
            await serviceManager.BookByAuthorService.DeleteBook_By_Author(authorId, id);
            return NoContent();
        }
    }
}
