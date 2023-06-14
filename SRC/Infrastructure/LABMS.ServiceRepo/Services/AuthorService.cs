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
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceRepository.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AuthorService(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<AuthorDto> CreateAuthor(AuthorForCreationDto author)
        {
            var authorToCreate = _mapper.Map<Author>(author);
            _repositoryManager.AuthorRepository.CreateAuthor(authorToCreate);
            await _repositoryManager.SaveAsync();
            var authorCreated = _mapper.Map<AuthorDto>(authorToCreate);
            return authorCreated;
        }

        public async Task DeleteAuthor(int authorId)
        {
            var author = await CheckIfAuthorExistAndReturnAuthor(authorId, false);
            _repositoryManager.AuthorRepository.DeleteAuthor(author);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorAsync(bool trackChanges)
        {
            var authors = await _repositoryManager.AuthorRepository.GetAllAuthorsAsync(trackChanges);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return authorsDto;
        }

        public async Task<AuthorDto> GetAuthorByIdAsync(int id)
        {
            var author = CheckIfAuthorExistAndReturnAuthor(id, false);
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        public async Task UpdateAuthor(AuthorForUpdate author)
        {
            await CheckIfAuthorExistAndReturnAuthor(author.AuthorId, false);
            var authorUpdate = _mapper.Map<Author>(author);
            _repositoryManager.AuthorRepository.UpdateAuthor(authorUpdate);
            await _repositoryManager.SaveAsync();
            /*var authorDto = _mapper.Map<AuthorDto>(authorUpdate);
            return authorDto;*/
        }

        //private methods to check if address exists and return the value 
        //Reusable codes
        private async Task<Author> CheckIfAuthorExistAndReturnAuthor(int id, bool trackChanges)
        {
            var author = await _repositoryManager.AuthorRepository.GetAuthorByIdAsync(id, trackChanges)
                ?? throw new AuthorNotFoundException(id);
            return author;
        }
    }
}
