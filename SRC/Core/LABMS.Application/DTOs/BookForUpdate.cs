using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LABMS.Application.DTOs
{
    public class BookForUpdate
    {
        [Key]
        public int Isbn { get; set; }
    }
}
