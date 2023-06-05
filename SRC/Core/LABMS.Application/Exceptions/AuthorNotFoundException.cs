using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class AuthorNotFoundException:NotFoundException
    {
        public AuthorNotFoundException(int id):base($"The author with id {id} is not found in the database")
        {
            
        }
    }
}
