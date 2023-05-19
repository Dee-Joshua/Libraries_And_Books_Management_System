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
        Task<IEnumerable<Books_At_Library>> GetAllBooks_At_LibrariesAsync(bool trackChanges);
        Task<Books_At_Library> GetBooks_At_LibraryByIdAsync(int Id, bool trackChanges);
        Task<Books_At_Library> GetBooks_At_LibraryByQuantity(int Quantity_In_Stock, bool trackchanges);
        void CreateBooks_At_Library(Books_At_Library books_At_Library);
        void DeleteBooks_At_Library(Books_At_Library books_At_Library);
    }
}
