using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForUpdate
{
    public class AuthorForUpdate
    {
        [Key]
        public int AuthorId { get; set; }
    }
}
