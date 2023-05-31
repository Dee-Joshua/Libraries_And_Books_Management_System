using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs
{
    public class MemberDto
    {
        public int MemberId { get; set; }

        public int Member_AddressId { get; set; }

        public string? Gender { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int PhoneNumber { get; set; }

        public string? EmailAddress { get; set; }
    }
}
