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
    internal sealed class Books_By_Author_Repository : RepositoryBase<Books_By_Author>, IBooks_By_Author_Repository
    {
        public Books_By_Author_Repository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateBooks_By_Author(Books_By_Author books_By_Author) => Create(books_By_Author);

        public void DeleteBooks_By_Author(Books_By_Author books_By_Author) => Delete(books_By_Author);

        public async Task<IEnumerable<Books_By_Author>> GetAllBooks_By_AuthorsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.AuthorId)
                .ToListAsync();
        }

        public async Task<Books_By_Author> GetBooks_By_AuthorByIdAsync(int isbn, int authorId, bool trackChanges)
        {
            return await FindByCondition(x => x.Isbn.Equals(isbn) && x.AuthorId.Equals(authorId), trackChanges).FirstOrDefaultAsync();
        }
    }
}
