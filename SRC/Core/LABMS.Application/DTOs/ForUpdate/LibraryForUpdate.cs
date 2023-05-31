using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForUpdate
{
    public class LibraryForUpdate
    {
        [Key]
        public int LibraryId { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        [StringLength(200, ErrorMessage = "Library Details cannot be more than 200 words")]
        public string? LibraryDetails { get; set; }
    }
}
