using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(string categoryName)
            : base($"The Book Category {categoryName} doesn't exist in the database")
        {
        }
    }
}
