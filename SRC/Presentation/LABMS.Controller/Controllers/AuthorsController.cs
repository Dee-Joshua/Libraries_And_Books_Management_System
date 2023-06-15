using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForUpdate;
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> AddAuthur([FromBody] AuthorForCreationDto authorForCreation)
        {
            var authorCreated = await serviceManager.AuthorService.CreateAuthor(authorForCreation);
            return CreatedAtAction(nameof(GetAuthorById), new {  id = authorCreated.AuthorId }, authorCreated);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody]AuthorForUpdate authorForUpdate)
        {
            if (id.Equals(0))
            {
                return BadRequest("Id cannot be 0");
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
