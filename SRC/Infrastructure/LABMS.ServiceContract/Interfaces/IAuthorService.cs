using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthorAsync(bool trackChanges);
        Task<AuthorDto> GetAuthorByIdAsync(int id);
        Task<AuthorDto> CreateAuthor(AuthorForCreationDto author);
        Task UpdateAuthor(AuthorForUpdate author);
        Task DeleteAuthor(int authorId);
    }
}
