using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForUpdate;
using LABMS.ServiceContract.Common;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LABMS.Controller.Controllers
{
    [Route("api/members")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public MembersController(IServiceManager service)
        {
            serviceManager = service;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult> GetAllMember()
        {
            var members = await serviceManager.MemberService.GetAllMembersAsync(false);
            return Ok(members);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}", Name= "GetMember")]
        public async Task<ActionResult> GetMember(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            var member = await serviceManager.MemberService.GetMemberById(id, false);
            return Ok(member);
        }

        // POST api/<MembersController>
        [HttpPost]
        public async Task<ActionResult> AddMember([FromBody] MemberForCreation memberToCreate)
        {
            if(memberToCreate == null)
            {
                return BadRequest("Input cannot be null");
            }
            var memberCreated = serviceManager.MemberService.CreateMember(memberToCreate);
            return CreatedAtAction(nameof(GetMember),  new { id = memberCreated.MemberId }, memberCreated);
        }

        // PUT api/<MembersController>/5
        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] MemberForUpdate memberForUpdate)
        {
            if(memberForUpdate == null)
            {
                return BadRequest("Input cannot be null");
            }
            await serviceManager.MemberService.UpdateMember(memberForUpdate);
            return NoContent();
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id cannot be 0");
            }
            await serviceManager.MemberService.DeleteMember(id);
            return NoContent();
        }
    }
}
