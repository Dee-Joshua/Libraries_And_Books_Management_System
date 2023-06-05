using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LABMS.Domain.Common;

namespace LABMS.Domain.entities
{
    public class Books_By_Author : BaseEntity
    {
        // Composite primary key consisting of the foreign keys
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Book))]
        public int Isbn { get; set; }

        // Navigation property for the many-to-many relationship        
        public virtual Author? Author { get; set; }
        public virtual Book? Book { get; set; }
    }
}
