using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class MemberRequest
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

        // Navigation property for the one-to-many relationship
        public virtual Member? Member { get; set; }
        public virtual Book? Book { get; set; }
    }

}
