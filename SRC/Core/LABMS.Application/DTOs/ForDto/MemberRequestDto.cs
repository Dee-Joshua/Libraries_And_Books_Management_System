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
    public class MemberRequestDto
    {
        public int RequestId { get; set; }

        public int MemberId { get; set; }
        public int LibraryId { get; set; }

        public int Isbn { get; set; }

        public DateTime DateRequested { get; set; }

        public DateTime DateLocated { get; set; }
    }
}
