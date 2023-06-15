using LABMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class Book : BaseEntity
    {
        [Key]
        public int Isbn { get; set; }

        [Required(ErrorMessage = "Book title is required.")]
        [StringLength(100, ErrorMessage = "Book title cannot exceed 100 characters.")]
        public string? BookTitle { get; set; }

        [Display(Name = "Date of Publication")]
        [DataType(DataType.Date)]
        public DateTime? Date_Of_Publication { get; set; }

        // Navigation property for the one-to-many relationship
        public virtual ICollection<MemberRequest>? MemberRequests { get; set; }
        public virtual ICollection<Books_At_Library>? Books_At_Libraries { get; set; }
        // Navigation property for the many-to-many relationship
        public virtual ICollection<Books_By_Author>? Books_By_Authors { get; set; }
        public virtual ICollection<Books_By_Category>? Books_By_Categories { get; set; }
    }

}
