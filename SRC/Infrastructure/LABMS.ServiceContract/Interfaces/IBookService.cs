using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges);
        Task<BookDto> GetBooksById(int id, bool trackChanges);
        Task<IEnumerable<BookDto>> GetAllBookByAuthorAsync(int authorId, bool trackChanges);
        Task<IEnumerable<BookDto>> GetAllBooksRequested(bool trackChanges);//pulls all member_request
        Task<IEnumerable<BookDto>> GetAllBooksRequestedByLibraryId(int libraryId, bool trackChanges);//pulls specific book in member_request
        Task<IEnumerable<BookDto>> GetAllBooksRequestedByMemberId(int memberId, bool trackChanges);//pulls books requested by member in member_request
        Task<IEnumerable<BookDto>> GetBooksByCategories(int categoryId, int bookId, bool trackChanges);
        Task<BookDto> CreateBook(BookForCreation bookCreate);
        //Task UpdateBook(BookForUpdate bookUpdate);
        Task DeleteBook(int id);
    }
}
