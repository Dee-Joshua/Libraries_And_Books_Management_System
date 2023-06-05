using LABMS.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Common
{
    public interface IServiceManager
    {
        IMemberService MemberService { get; }
        IAddressService AddressService { get; }
        ILibraryService LibraryService { get; }
        IBookService BookService { get; }
        IAuthorService AuthorService { get; }
        IAmazonBooksService AmazonBooksService { get; }
        IBooks_At_Library_Service BookAtLibraryService { get; } 
        IBooks_By_Author_Service BookByAuthorService { get; }
        IMemberRequestService MemberRequestService { get; }
    }
}
