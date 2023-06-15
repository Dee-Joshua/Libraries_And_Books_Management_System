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
    internal sealed class Books_By_Category_Repository : RepositoryBase<Books_By_Category>, IBooks_By_Category_Repository
    {
        public Books_By_Category_Repository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateBooks_By_Category(Books_By_Category books_By_Category) => Create(books_By_Category);

        public void DeleteBooks_By_Category(Books_By_Category books_By_Category) => Delete(books_By_Category);

        public async Task<IEnumerable<Books_By_Category>> GetAllBooks_By_CategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.CategoryId)
                .ToListAsync();
        }

        public async Task<Books_By_Category> GetBooks_By_CategoryByIdAsync(int isbn, int categoryId, bool trackChanges)
        {
            return await FindByCondition(x => x.Isbn.Equals(isbn) && x.CategoryId.Equals(categoryId), trackChanges).FirstOrDefaultAsync();
        }
    }
}
