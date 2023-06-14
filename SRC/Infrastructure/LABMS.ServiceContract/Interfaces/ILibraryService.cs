using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Interfaces
{
    public interface ILibraryService
    {
        Task<IEnumerable<LibraryDto>> GetAllLibraryAsync(bool trackChanges);
        Task<LibraryDto> GetLibraryById(int id, bool trackChanges);
        LibraryDto CreateLibrary(LibraryForCreationDto library);
        Task UpdateLibrary(LibraryForUpdate library);
        Task DeleteLibrary(int id);
    }
}
