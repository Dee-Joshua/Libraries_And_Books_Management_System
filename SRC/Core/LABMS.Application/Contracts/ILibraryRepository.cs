using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
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
        Task<Library> GetLibraryByIdAsync(int id, bool trackChanges);
        Task<Library> GetLibraryByName(string libraryName, bool trackChanges);
        void CreateLibrary(Library library);
        void UpdateLibrary(Library library);
        void DeleteLibrary(Library library);
    }
}
