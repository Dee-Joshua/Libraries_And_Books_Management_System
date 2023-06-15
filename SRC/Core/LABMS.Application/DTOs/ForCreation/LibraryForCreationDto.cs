using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForCreation
{
    public class LibraryForCreationDto
    {
        [ForeignKey(nameof(Address))]
        public int AddressId { get; init; }

        [Required]
        [MaxLength(50)]
        public string? LibraryName { get; init; }

        [StringLength(200, ErrorMessage = "Library Details cannot be more than 200 words")]
        public string? LibraryDetails { get; init; }
        public AddressForCreationDto? AddressForCreation { get; init; }
    }
}
