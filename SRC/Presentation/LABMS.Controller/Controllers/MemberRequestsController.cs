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

namespace LABMS.Controller.Controllers
{
    [Route("api/members/{memberId}/requests")]
    [ApiController]
    public class MemberRequestsController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public MemberRequestsController(IServiceManager service)
        {
            serviceManager = service;
        }
        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult> GetAllMemberRequest(int memberId)
        {
            if (memberId.Equals(0))
            {
                return BadRequest("member id cannot be 0");
            }
            var members = await serviceManager.MemberRequestService.GetAllMemberRequestByMemberId(memberId, false);
            return Ok(members);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}",Name = "GetMemberRequestById")]
        public async Task<ActionResult> GetMemberRequestById(int memberId, int id)
        {
            if (id.Equals(0) || memberId.Equals(0))
            {
                return BadRequest("Id cannot be 0");
            }
            var member = await serviceManager.MemberRequestService.GetMemberRequestByIdAsync(memberId, id, false);
            return Ok(member);
        }

        // POST api/<MembersController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> AddMemberRequest(int memberId, [FromBody] MemberRequestForCreationDto memberRequestToCreate)
        {
            if(memberRequestToCreate.MemberId !=memberId)
            {
                return BadRequest("Wrong user Id inputed");
            }
            var memberRequestCreated = await serviceManager.MemberRequestService.CreateMemberRequest(memberRequestToCreate);
            return CreatedAtAction(nameof(GetMemberRequestById), new { memberId, id = memberRequestCreated.RequestId }, memberRequestCreated);
        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> CloseMemberRequest(int memberId, int id)
        {
            if (id.Equals(0) || memberId.Equals(0))
            {
                return BadRequest("Id's cannot be 0");
            }
            await serviceManager.MemberRequestService.CloseMemberRequest(memberId, id);
            return NoContent();
        }
    }
}
