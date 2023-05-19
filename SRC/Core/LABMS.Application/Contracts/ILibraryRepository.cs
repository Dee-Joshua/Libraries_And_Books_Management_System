using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface ILibraryRepository
    {
        Task<IEnumerable<Library>> GetAllLibrariesAsync(bool trackChanges);
        Task<Library> GetLibraryByIdAsync(int Id, bool trackChanges);
        Task<Library> GetLibraryByName(string LibraryName, bool trackchanges);
        void CreateLibrary(Library library);
        void DeleteLibrary(Library library);
    }
}
