using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Category name must be between 3 and 50 characters.")]
        public string? CategoryName { get; set; }

        // Navigation property for the many-to-many relationship
        public virtual ICollection<Books_By_Category>? Books_By_Categories { get; set; }
    }
}
