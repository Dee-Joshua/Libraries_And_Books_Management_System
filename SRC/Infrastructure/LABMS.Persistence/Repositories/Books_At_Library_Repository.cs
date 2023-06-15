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
    internal sealed class Books_At_Library_Repository : RepositoryBase<Books_At_Library>, IBooks_At_Library_Repository
    {
        public Books_At_Library_Repository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateBooks_At_Library(Books_At_Library books_At_Library) => Create(books_At_Library);

        public void DeleteBooks_At_Library(Books_At_Library books_At_Library) => Delete(books_At_Library);

        public async Task<IEnumerable<Books_At_Library>> GetAllBooks_At_LibrariesAsync( bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.Isbn)
                .ToListAsync();
        }

        public async Task<IEnumerable<Books_At_Library>> GetBooks_At_LibraryByBookIdAsync(int isbn, bool trackChanges)
        {
            return await FindByCondition(x=>x.Isbn.Equals(isbn),trackChanges).ToListAsync();
        }

        public async Task<Books_At_Library> GetBooks_At_LibraryByIdAsync(int isbn, int libraryId, bool trackChanges)
        {
            return await FindByCondition(x => x.Isbn.Equals(isbn) && x.LibraryId.Equals(libraryId), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Books_At_Library>> GetBooks_At_LibraryByLibraryIdAsync(int libraryId, bool trackChanges)
        {
            return await FindByCondition(x=>x.LibraryId.Equals(libraryId),trackChanges).ToListAsync();
        }

        public async Task<IEnumerable<Books_At_Library>> GetBooks_At_LibraryByQuantity(int min_Quantity_In_Stock, bool trackChanges)
        {
            return await FindAll(trackChanges).Where(x => x.Quantity_In_Stock <= min_Quantity_In_Stock).ToListAsync();
        }

        public void UpdateBook_At_Library(Books_At_Library books_At_Library)
        {
            Update(books_At_Library);
        }
    }
}
