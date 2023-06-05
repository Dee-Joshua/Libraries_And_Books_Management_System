using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IBooks_At_Library_Repository
    {
        Task<IEnumerable<Books_At_Library>> GetAllBooks_At_LibrariesAsync( bool trackChanges);
        Task<Books_At_Library> GetBooks_At_LibraryByIdAsync(int isbn, int libraryId, bool trackChanges);
        Task<IEnumerable<Books_At_Library>> GetBooks_At_LibraryByBookIdAsync(int isbn,bool trackChanges);
        Task<IEnumerable<Books_At_Library>> GetBooks_At_LibraryByLibraryIdAsync(int libraryId, bool trackChanges);
        Task<IEnumerable<Books_At_Library>> GetBooks_At_LibraryByQuantity(int min_Quantity_In_Stock, bool trackChanges);
        void CreateBooks_At_Library(Books_At_Library books_At_Library);
        void UpdateBook_At_Library(Books_At_Library books_At_Library);
        void DeleteBooks_At_Library(Books_At_Library books_At_Library);
    }
}
