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
    public interface IBooks_At_Library_Service
    {
        Task<IEnumerable<Books_At_LibraryDto>> GetAllBooksAtLibrary(bool trackChanges);
        Task<IEnumerable<Books_At_LibraryDto>> GetAllMemberRequestById(int id, bool trackChanges);  
        Task<IEnumerable<Books_At_LibraryDto>> GetAllBooksAtLibraryByLibraryId(int libraryId, bool trackChanges);
        Task<IEnumerable<Books_At_LibraryDto>> GetAllBooksAtLibraryByBookId(int bookId, bool trackChanges);
        Task<Books_At_LibraryDto> CreateBookAtLibrary(Books_At_LibraryForCreationDto books_At_Library);
        Task UpdateBookAtLibrary(Books_At_LibraryForUpdate books_At_Library);
        Task DeleteBookAtLibrary(int libraryId, int bookId);
    }
}
