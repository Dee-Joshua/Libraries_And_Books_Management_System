using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.DTOs.ForUpdate
{
    public record Books_At_LibraryForUpdate
    {
        public int LibraryId { get; init; }

        public int Isbn { get; init; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity_In_Stock { get; init; }
    }
}
