using LABMS.Application.Contracts;
using LABMS.Domain.entities;
using LABMS.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Persistence.Repositories
{
    internal sealed class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAuthor(Author author) => Create(author);

        public void DeleteAuthor(Author author) => Delete(author);

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.AuthorId)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.AuthorId.Equals(id), trackChanges).FirstOrDefaultAsync();
        }
    }
}
