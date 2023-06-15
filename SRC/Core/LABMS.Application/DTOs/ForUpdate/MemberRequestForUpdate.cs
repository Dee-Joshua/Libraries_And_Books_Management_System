using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForUpdate
{
    public class MemberRequestForUpdate
    {
        [Key]
        public int RequestId { get; set; }

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
