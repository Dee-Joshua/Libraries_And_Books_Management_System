using AutoMapper;
using LABMS.Application.Common;
using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using LABMS.Application.Exceptions;
using LABMS.Domain.entities;
using LABMS.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceRepository.Services
{
    public class Books_At_LibrariesService : IBooks_At_Library_Service
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public Books_At_LibrariesService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<Books_At_LibraryDto> CreateBookAtLibrary(Books_At_LibraryForCreation books_At_Library)
        {
            var bookLibrary = _mapper.Map<Books_At_Library>(books_At_Library);
            _repositoryManager.BooksAtLibraryRepository.CreateBooks_At_Library(bookLibrary);
            await _repositoryManager.SaveAsync();
            var bookLibraryDto = _mapper.Map<Books_At_LibraryDto>(bookLibrary);
            return bookLibraryDto;
        }

        public async Task DeleteBookAtLibrary(int libraryId, int bookId)
        {
            var bookLibrary = await _repositoryManager.BooksAtLibraryRepository
                .GetBooks_At_LibraryByIdAsync(bookId, libraryId, false)
                ?? throw new Book_At_LibraryNotFoundException(bookId,libraryId);
            _repositoryManager.BooksAtLibraryRepository.DeleteBooks_At_Library(bookLibrary);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Books_At_LibraryDto>> GetAllBooksAtLibrary(bool trackChanges)
        {
            var booksLibraries = await _repositoryManager.BooksAtLibraryRepository
                .GetAllBooks_At_LibrariesAsync(trackChanges)
                ?? throw new Book_At_LibraryNotFoundException();
            var booksLibrariesDto = _mapper.Map<IEnumerable<Books_At_LibraryDto>>(booksLibraries);
            return booksLibrariesDto;
        }

        public async Task<IEnumerable<Books_At_LibraryDto>> GetAllBooksAtLibraryByBookId(int bookId, bool trackChanges)
        {
            var bookInLibrary = await _repositoryManager.BooksAtLibraryRepository
                .GetBooks_At_LibraryByBookIdAsync(bookId, trackChanges)
                ?? throw new Book_At_LibraryNotFoundException();
            var bookInLibraryDto = _mapper.Map<IEnumerable<Books_At_LibraryDto>>(bookInLibrary);
            return bookInLibraryDto;

        }

        public async Task<IEnumerable<Books_At_LibraryDto>> GetAllBooksAtLibraryByLibraryId(int libraryId, bool trackChanges)
        {
            var bookInLibrary = await _repositoryManager.BooksAtLibraryRepository
                .GetBooks_At_LibraryByLibraryIdAsync(libraryId, trackChanges)
                ?? throw new Book_At_LibraryNotFoundException();
            var bookInLibraryDto = _mapper.Map<IEnumerable<Books_At_LibraryDto>>(bookInLibrary);
            return bookInLibraryDto;
        }


        public async Task UpdateBookAtLibrary(Books_At_LibraryForUpdate books_At_Library)
        {
            var bookInLibrary = await _repositoryManager.BooksAtLibraryRepository
                .GetBooks_At_LibraryByIdAsync(books_At_Library.Isbn,books_At_Library.LibraryId,false)
                ??throw new Book_At_LibraryNotFoundException(books_At_Library.Isbn,books_At_Library.LibraryId);
            var bookLibraryUpdate = _mapper.Map<Books_At_Library>(books_At_Library);
            _repositoryManager.BooksAtLibraryRepository.UpdateBook_At_Library(bookLibraryUpdate);
            await _repositoryManager.SaveAsync();
        }
        public Task<IEnumerable<Books_At_LibraryDto>> GetAllMemberRequestById(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
