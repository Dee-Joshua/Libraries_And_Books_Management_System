using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForDto
{
    public class AmazonBooksDto
    {
        public int Isbn { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public DateTime Date_Of_Publication { get; set; }

        public int Amazon_Star_Rating { get; set; }

        public string? Publisher { get; set; }

        public double ListPrice { get; set; }

        public double AmazonPrice { get; set; }

        public double YourSaving { get; set; }
    }
}
