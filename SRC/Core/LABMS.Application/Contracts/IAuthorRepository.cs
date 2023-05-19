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
        Task<Author> GetAuthorByIdAsync(int Id, bool trackChanges);
        Task<Author> GetAuthorByName(string FirstName, string LastName, bool trackchanges);
        void CreateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
