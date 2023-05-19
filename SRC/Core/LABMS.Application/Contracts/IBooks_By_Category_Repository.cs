using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IBooks_By_Category_Repository
    {
        Task<IEnumerable<Books_By_Category>> GetAllBooks_By_CategoriesAsync(bool trackChanges);
        Task<Books_By_Category> GetBooks_By_CategoryByIdAsync(int Id, bool trackChanges);
        void CreateBooks_By_Category(Books_By_Category books_By_Category);
        void DeleteBooks_By_Category(Books_By_Category books_By_Category);
    }
}
