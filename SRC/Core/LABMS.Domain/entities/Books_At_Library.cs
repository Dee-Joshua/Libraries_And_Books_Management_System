using LABMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class Books_At_Library : BaseEntity
    {
        [ForeignKey(nameof(Library))]
        public int LibraryId { get; set; }

        [ForeignKey(nameof(Book))]
        public int Isbn { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]
        public int Quantity_In_Stock { get; set; }

        // Navigation property for the one-to-many relationship
        public virtual Library? Library { get; set; }
        public virtual Book? Book { get; set; }
    }

}
