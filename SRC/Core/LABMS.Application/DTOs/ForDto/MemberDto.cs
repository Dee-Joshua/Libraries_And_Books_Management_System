using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForDto
{
    public class MemberDto
    {
        public int MemberId { get; init; }

        public string? Gender { get; init; }

        public string? FirstName { get; init; }

        public string? LastName { get; init; }

        public int PhoneNumber { get; init; }

        public string? EmailAddress { get; init; }
        public AddressDto? Address { get; init; }
    }
}
