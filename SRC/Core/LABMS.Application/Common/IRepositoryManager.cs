using LABMS.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Common
{
    public interface IRepositoryManager
    {
        IAddressRepository AddressRepository { get; }
        IAmazon_Books_Repository AmazonBooksRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IBookRepository BookRepository { get; }
        IBooks_At_Library_Repository BooksAtLibraryRepository { get; }
        IBooks_By_Author_Repository BooksByAuthorRepository { get; }
        IBooks_By_Category_Repository BooksByCategoryRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ILibraryRepository LibraryRepository { get; }
        IMember_Request_Repository MemberRequestRepository { get; }
        IMemberRepository MemberRepository { get; }
        Task SaveAsync();
    }
}
