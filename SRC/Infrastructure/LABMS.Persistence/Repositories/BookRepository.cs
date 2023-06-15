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
    internal sealed class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateBook(Book book) => Create(book);

        public void DeleteBook(Book book) => Delete(book);

        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.Isbn)
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.Isbn.Equals(id), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookByTitle(string bookTitle, bool trackChanges)
        {
            return await FindByCondition(x => x.BookTitle.Contains(bookTitle), trackChanges).FirstOrDefaultAsync();
        }
    }
}
