using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges);
        Task<Author> GetAuthorByIdAsync(int id, bool trackChanges);
        void CreateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
