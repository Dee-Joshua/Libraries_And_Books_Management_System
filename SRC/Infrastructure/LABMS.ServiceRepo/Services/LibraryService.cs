using AutoMapper;
using LABMS.Application.Common;
using LABMS.Application.Contracts;
using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using LABMS.Application.Exceptions;
using LABMS.Domain.entities;
using LABMS.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceRepository.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public LibraryService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public LibraryDto CreateLibrary(LibraryForCreationDto library)
        {
            var libraryToCreate = _mapper.Map<Library>(library);
            _repositoryManager.LibraryRepository.CreateLibrary(libraryToCreate);
            var libraryCreated = _mapper.Map<LibraryDto>(libraryToCreate);
            return libraryCreated;
        }

        public async Task DeleteLibrary(int libraryId)
        {
            var library = await CheckIfLibraryExistAndReturnLibrary(libraryId, false);
            _repositoryManager.LibraryRepository.DeleteLibrary(library);
            await _repositoryManager.SaveAsync();

        }

        public async Task<IEnumerable<LibraryDto>> GetAllLibraryAsync(bool trackChanges)
        {
            var libraries = await _repositoryManager.LibraryRepository.GetAllLibrariesAsync(trackChanges);
            var librariesDto = _mapper.Map<IEnumerable<LibraryDto>>(libraries);
            return librariesDto;
        }

        public async Task<LibraryDto> GetLibraryById(int id, bool trackChanges)
        {
            var library = await CheckIfLibraryExistAndReturnLibrary(id, trackChanges);
            var libraryDto = _mapper.Map<LibraryDto>(library);
            return libraryDto;

        }

        public async Task UpdateLibrary(LibraryForUpdate libraryToUpdate)
        {
            await CheckIfLibraryExistAndReturnLibrary(libraryToUpdate.LibraryId, false);
            var library = _mapper.Map<Library>(libraryToUpdate);
            _repositoryManager.LibraryRepository.UpdateLibrary(library);
            await _repositoryManager.SaveAsync();
        }

        //private methods to check if address exists and return the value 
        //Reusable codes
        private async Task<Library> CheckIfLibraryExistAndReturnLibrary(int id, bool trackChanges)
        {
            var library = await _repositoryManager.LibraryRepository.GetLibraryByIdAsync(id, false)
                ?? throw new LibraryNotFoundException(id);
            return library;
        }
    }
}
