using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class Books_By_Author
    {
        // Composite primary key consisting of the foreign keys
        [Key, Column(Order = 0)]
        public int AuthorId { get; set; }

        [Key, Column(Order = 1)]
        public int Isbn { get; set; }


        // Foreign key properties referencing the related entities
        [ForeignKey(nameof(Author))]
        public virtual Author? Author { get; set; }

        [ForeignKey(nameof(Book))]
        public virtual Book? Book { get; set; }
    }
}
