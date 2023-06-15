using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Exceptions
{
    public class BookOutOfStockException:NotFoundException
    {
        public BookOutOfStockException(int isbn,int libraryId):base($"The book with isbn {isbn} from library with id {libraryId} is out of stock")
        {
            
        }
    }
}
