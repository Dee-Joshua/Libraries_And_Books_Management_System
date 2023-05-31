using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LABMS.Application.DTOs
{
    public class BookForCreation
    {
        [Required(ErrorMessage = "Book title is required.")]
        [StringLength(100, ErrorMessage = "Book title cannot exceed 100 characters.")]
        public string? BookTitle { get; set; }

        [Display(Name = "Date of Publication")]
        [DataType(DataType.Date)]
        public DateTime? Date_Of_Publication { get; set; }
    }
}
