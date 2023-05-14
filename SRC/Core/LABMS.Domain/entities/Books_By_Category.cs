using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Domain.entities
{
    public class Books_By_Category
    {
        // Composite primary key consisting of the foreign keys
        [Key, Column(Order = 0)]
        public int CategoryId { get; set; }

        [Key, Column(Order = 1)]
        public int Isbn { get; set; }


        // Foreign key properties referencing the related entities
        [ForeignKey(nameof(Category))]
        public virtual Category? Category { get; set; }

        [ForeignKey(nameof(Book))]
        public virtual Book? Book { get; set; }
    }
}
