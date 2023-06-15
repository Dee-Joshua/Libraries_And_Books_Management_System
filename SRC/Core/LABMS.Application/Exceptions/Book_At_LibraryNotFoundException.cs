using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class Book_At_LibraryNotFoundException:NotFoundException
    {
        public Book_At_LibraryNotFoundException(int bookId,int libraryId):base($"The book with id {bookId} at library with id {libraryId} is not found in the database")
        {
            
        }
        public Book_At_LibraryNotFoundException():base($"No book at library was found in the database")
        {
            
        }
    }
}
