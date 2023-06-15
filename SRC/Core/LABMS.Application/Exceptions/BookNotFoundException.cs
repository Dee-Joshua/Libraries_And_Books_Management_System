using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class BookNotFoundException:NotFoundException
    {
        public BookNotFoundException(int id):base($"The book with the id {id} is not found in the database")
        {
            
        }
    }
}
