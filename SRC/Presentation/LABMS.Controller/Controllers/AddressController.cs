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
    [Route("api/members/{memberId}/address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public AddressController(IServiceManager service)
        {
            serviceManager = service;
        }

        // GET: api/<MembersController>
        [HttpGet(Name ="GetAddress")]
        public async Task<ActionResult> GetAddress(int memberId)
        {
            var address = await serviceManager.AddressService.GetAddressAsync(memberId, false);
            return Ok(address);
        }


        // POST api/<MembersController>
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> AddAddress(int memberId, [FromBody] AddressForCreationDto addressForCreation)
        {
            if( memberId.Equals(0))
            {
                return BadRequest("Id is invalid");
            }
            var addressCreated = await serviceManager.AddressService.CreateAddressAsync(memberId, addressForCreation);
            return CreatedAtAction(nameof(GetAddress), new { memberId, id = addressCreated.BaseId }, addressCreated);
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult> UpdateAddress(int memberId, [FromBody] AddressForUpdate addressForUpdate)
        {
            if ( memberId.Equals(0) || addressForUpdate.BaseId!=memberId)
            {
                return BadRequest("Invalid id");
            }
            await serviceManager.AddressService.UpdateAddressAsync(addressForUpdate, false);
            return NoContent();
        }

        // GET api/<MembersController>/5
        /* [HttpGet("{id}", Name = "GetMemberRequestById")]
         public async Task<ActionResult> GetMemberRequestById(int memberId, int id)
         {
             if (id.Equals(0) || memberId.Equals(0))
             {
                 return BadRequest("Id cannot be 0");
             }
             var member = await serviceManager.MemberRequestService.GetMemberRequestByIdAsync(memberId, id, false);
             return Ok(member);
         }*/
        // DELETE api/<MembersController>/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult> CloseMemberRequest(int memberId, int id)
        {
            if (id.Equals(0) || memberId.Equals(0))
            {
                return BadRequest("Id's cannot be 0");
            }
            await serviceManager.MemberRequestService.CloseMemberRequest(memberId, id);
            return NoContent();
        }*/
    }
}
