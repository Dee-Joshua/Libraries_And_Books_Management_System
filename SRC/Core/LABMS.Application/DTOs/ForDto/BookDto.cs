using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LABMS.Application.DTOs.ForDto
{
    public class BookDto
    {
        public int Isbn { get; set; }

        public string? BookTitle { get; set; }

        public DateTime? Date_Of_Publication { get; set; }
    }
}
