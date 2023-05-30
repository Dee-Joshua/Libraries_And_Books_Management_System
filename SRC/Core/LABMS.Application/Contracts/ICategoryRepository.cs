using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges);
        Task<Category> GetCategoryByIdAsync(int id, bool trackChanges);
        Task<Category> GetCategoryByName(string categoryName, bool trackChanges);
        void CreateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
