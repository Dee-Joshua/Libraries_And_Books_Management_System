using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForCreation
{
    public class MemberRequestForCreation
    {
        [ForeignKey(nameof(Member))]
        public int MemberId { get; set; }

        [ForeignKey(nameof(Book))]
        public int Isbn { get; set; }

        [Required(ErrorMessage = "The date requested is required.")]
        public DateTime DateRequested { get; set; }

        [Required(ErrorMessage = "The date located is required.")]
        public DateTime DateLocated { get; set; }
    }
}
