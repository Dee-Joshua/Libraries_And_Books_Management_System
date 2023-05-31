using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs
{
    public class AmazonBooksForUpdate
    {
        [Key]
        public int Isbn { get; set; }

        [Range(0, 5, ErrorMessage = "Star rating must be between 0 and 5.")]
        public int Amazon_Star_Rating { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "List price must be greater than 0.")]
        public double ListPrice { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Amazon price must be greater than 0.")]
        public double AmazonPrice { get; set; }

        [ReadOnly(true)]
        public double YourSaving { get; set; }
    }
}
