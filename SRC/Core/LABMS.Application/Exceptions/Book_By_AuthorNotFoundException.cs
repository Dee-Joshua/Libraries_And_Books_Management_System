using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class Book_By_AuthorNotFoundException:NotFoundException
    {
        public Book_By_AuthorNotFoundException(int authorId, int isbn):base($"The author with id {authorId} and book with id {isbn} is not found in the database")
        {
            
        }
        public Book_By_AuthorNotFoundException():base("The Book_By_Author is not found in the database")
        {
            
        }
    }
}
