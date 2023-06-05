using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class LibraryNotFoundException : NotFoundException
    {
        public LibraryNotFoundException(int id)
            : base($"The Library with id {id} doesn't exist in the database")
        {
        }
    }
}
