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
    internal sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCategory(Category category) => Create(category);

        public void DeleteCategory(Category category) => Delete(category);

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.CategoryId)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.CategoryId.Equals(id), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<Category> GetCategoryByName(string categoryName, bool trackChanges)
        {
            return await FindByCondition(x => x.CategoryName.Contains(categoryName), trackChanges).FirstOrDefaultAsync();
        }
    }
}
