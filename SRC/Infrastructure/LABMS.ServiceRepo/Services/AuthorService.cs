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
        public async Task<AuthorDto> CreateAuthor(AuthorForCreation author)
        {
            var authorToCreate = _mapper.Map<Author>(author);
            _repositoryManager.AuthorRepository.CreateAuthor(authorToCreate);
            await _repositoryManager.SaveAsync();
            var authorCreated = _mapper.Map<AuthorDto>(authorToCreate);
            return authorCreated;
        }

        public async Task DeleteAuthor(int authorId)
        {
            var author = await _repositoryManager.AuthorRepository.GetAuthorByIdAsync(authorId, false)
                ?? throw new AuthorNotFoundException(authorId);
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
            var author = await _repositoryManager.AuthorRepository.GetAuthorByIdAsync(id, false)
                ??throw new AuthorNotFoundException(id);
            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }

        public async Task UpdateAuthor(AuthorForUpdate author)
        {
            var authorToUpdate = await _repositoryManager.AuthorRepository
                .GetAuthorByIdAsync(author.AuthorId,false)
                ??throw new AuthorNotFoundException(author.AuthorId);
            var authorUpdate = _mapper.Map<Author>(author);
            _repositoryManager.AuthorRepository.UpdateAuthor(authorUpdate);
            await _repositoryManager.SaveAsync();
            /*var authorDto = _mapper.Map<AuthorDto>(authorUpdate);
            return authorDto;*/
        }
    }
}
