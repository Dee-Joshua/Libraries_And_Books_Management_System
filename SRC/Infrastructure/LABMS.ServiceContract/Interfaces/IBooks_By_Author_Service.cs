using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Interfaces
{
    public interface IBooks_By_Author_Service
    {
        Task<IEnumerable<Books_By_AuthorDto>> GetAllBooks_By_Author(bool trackChanges);
        Task<IEnumerable<Books_By_AuthorDto>> GetAllBooks_By_AuthorByAuthorIdAsync(int authorId, bool trackChanges);
        Task<Books_By_AuthorDto> GetAllBooks_By_AuthorByBookIdAsync(int bookId, bool trackChanges);
        Task<Books_By_AuthorDto> GetAllBooks_By_AuthorByAuthorBookIdIdAsync(int authorId, int bookId, bool trackChanges);
        Task<Books_By_AuthorDto> CreateBook_By_Author(Books_By_AuthorForCreationDto books_By_Author);
        Task DeleteBook_By_Author(int authorId, int bookId);

    }
}
