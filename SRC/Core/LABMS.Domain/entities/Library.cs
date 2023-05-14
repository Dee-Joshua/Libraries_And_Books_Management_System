using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class Library
    {
        [Key]
        public int LibraryId { get; set; }
        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? LibraryName { get; set; }

        public string? LibraryDetails { get; set; }
    }
}
