using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs
{
    public class LibraryDto
    {
        public int LibraryId { get; set; }

        public int AddressId { get; set; }

        public string? LibraryName { get; set; }

        public string? LibraryDetails { get; set; }
    }
}
