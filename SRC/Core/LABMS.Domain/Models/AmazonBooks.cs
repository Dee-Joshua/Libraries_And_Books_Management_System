using LABMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class AmazonBooks : BaseEntity
    {
        [Key]
        public int Isbn { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [StringLength(50, ErrorMessage = "Author cannot exceed 50 characters.")]
        public string? Author { get; set; }

        [Required(ErrorMessage = "Date of publication is required.")]
        [DataType(DataType.Date)]
        public DateTime Date_Of_Publication { get; set; }

        [Range(0, 5, ErrorMessage = "Star rating must be between 0 and 5.")]
        public int Amazon_Star_Rating { get; set; }

        [Required(ErrorMessage = "Publisher is required.")]
        [StringLength(50, ErrorMessage = "Publisher cannot exceed 50 characters.")]
        public string? Publisher { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "List price must be greater than 0.")]
        public double ListPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amazon price must be greater than 0.")]
        public double AmazonPrice { get; set; }

        [ReadOnly(true)]
        public double YourSaving { get; set; }
    }
}
