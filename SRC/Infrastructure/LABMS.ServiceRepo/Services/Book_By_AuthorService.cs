using AutoMapper;
using LABMS.Application.Common;
using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
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
    public class Book_By_AuthorService : IBooks_By_Author_Service
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public Book_By_AuthorService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<Books_By_AuthorDto> CreateBook_By_Author(Books_By_AuthorForCreation books_By_Author)
        {
            var bookAuthor = _mapper.Map<Books_By_Author>(books_By_Author);
            _repositoryManager.BooksByAuthorRepository.CreateBooks_By_Author(bookAuthor);
            await _repositoryManager.SaveAsync();
            var bookAuthorDto = _mapper.Map<Books_By_AuthorDto>(bookAuthor);
            return bookAuthorDto;
        }

        public async Task DeleteBook_By_Author(int authorId, int bookId)
        {
            var authorBook = await _repositoryManager.BooksByAuthorRepository
                .GetBook_By_AuthorbyAuthorId(authorId,false)
                ?? throw new Book_By_AuthorNotFoundException(authorId, bookId);
            var book = authorBook.Where(x=>x.Isbn.Equals(bookId)).FirstOrDefault();
            _repositoryManager.BooksByAuthorRepository.DeleteBooks_By_Author(book);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<Books_By_AuthorDto>> GetAllBooks_By_Author(bool trackChanges)
        {
            var authorBooks = await _repositoryManager.BooksByAuthorRepository
                .GetAllBooks_By_AuthorsAsync(trackChanges)
                ?? throw new Book_By_AuthorNotFoundException();
            var authorBooksDto = _mapper.Map<IEnumerable<Books_By_AuthorDto>>(authorBooks);
            return authorBooksDto;
        }

        public async Task<IEnumerable<Books_By_AuthorDto>> GetAllBooks_By_AuthorByAuthorIdAsync(int authorId, bool trackChanges)
        {
            var authorBooks = await _repositoryManager.BooksByAuthorRepository
                .GetBook_By_AuthorbyAuthorId(authorId,trackChanges)
                ?? throw new Book_By_AuthorNotFoundException();
            var authorBookDto = _mapper.Map<IEnumerable<Books_By_AuthorDto>>(authorBooks);
            return authorBookDto;
        }

        public async Task<Books_By_AuthorDto> GetAllBooks_By_AuthorByBookIdAsync(int bookId, bool trackChanges)
        {
            var authorbook = await _repositoryManager.BooksByAuthorRepository
                .GetBooks_By_AuthorByBookIdAsync(bookId,trackChanges)
                ??throw new Book_By_AuthorNotFoundException();
            var authorbookDto = _mapper.Map<Books_By_AuthorDto>(authorbook);
            return authorbookDto;   
        }
        public async Task<Books_By_AuthorDto> GetAllBooks_By_AuthorByAuthorBookIdIdAsync(int authorId, int bookId, bool trackChanges)
        {
            var authorBook = await _repositoryManager.BooksByAuthorRepository
                .GetBooks_By_AuthorByIdAsync(bookId, authorId, trackChanges)
                ?? throw new Book_By_AuthorNotFoundException();
            var authorBookDto = _mapper.Map<Books_By_AuthorDto>(authorBook);
            return authorBookDto;
        }

    }
}
