using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LABMS.Application.DTOs.ForCreation
{
    public class BookForCreationDto
    {
        [Required(ErrorMessage = "Book title is required.")]
        [StringLength(100, ErrorMessage = "Book title cannot exceed 100 characters.")]
        public string? BookTitle { get; init; }

        [Display(Name = "Date of Publication")]
        [DataType(DataType.Date)]
        public DateTime? Date_Of_Publication { get; init; }
        public Books_By_AuthorForCreationDto? Books_By_AuthorForCreation { get; init; }
    }
}
