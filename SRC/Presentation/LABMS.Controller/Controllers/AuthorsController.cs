using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForUpdate;
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
    [Route("api/authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public AuthorsController(IServiceManager service)
        {
            serviceManager = service;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult> GetAllAuthor()
        {
            var authors = await serviceManager.AuthorService.GetAllAuthorAsync(false);
            return Ok(authors);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}", Name = "GetAuthorById")]
        public async Task<ActionResult> GetAuthorById(int id)
        {
            if (id.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            }
            var author = await serviceManager.AuthorService.GetAuthorByIdAsync(id);
            return Ok(author);
        }

        // POST api/<MembersController>
        [HttpPost]
        public async Task<ActionResult> AddMemberRequest([FromBody] AuthorForCreation authorForCreation)
        {
            if (authorForCreation == null)
            {
                return BadRequest("Input cannot be null");
            }
            var authorCreated = await serviceManager.AuthorService.CreateAuthor(authorForCreation);
            return CreatedAtAction(nameof(GetAuthorById), new {  id = authorCreated.AuthorId }, authorCreated);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(AuthorForUpdate authorForUpdate)
        {
            if (authorForUpdate == null)
            {
                return BadRequest("Cannot be null");
            }
            await serviceManager.AuthorService.UpdateAuthor(authorForUpdate);
            return NoContent();

        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> CloseMemberRequest(int id)
        {
            if (id.Equals(0))
            {
                return BadRequest("Id's cannot be 0");
            }
            await serviceManager.AuthorService.DeleteAuthor(id);
            return NoContent();
        }
    }
}
