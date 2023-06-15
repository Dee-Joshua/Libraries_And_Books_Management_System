using LABMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class Library : BaseEntity
    {
        [Key]
        public int LibraryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LibraryName { get; set; }
        
        [StringLength(200,ErrorMessage="Library Details cannot be more than 200 words")]
        public string? LibraryDetails { get; set; }

        // Navigation property for the one-to-many relationship
        public Address? Address {get; set;}
        public virtual ICollection<Books_At_Library>? Books_At_Libraries { get; set; }
    }
}
