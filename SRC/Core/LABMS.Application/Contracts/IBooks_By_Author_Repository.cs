using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IBooks_By_Author_Repository
    {
        Task<IEnumerable<Books_By_Author>> GetAllBooks_By_AuthorsAsync(bool trackChanges);
        Task<Books_By_Author> GetBooks_By_AuthorByIdAsync(int isbn, int authorId, bool trackChanges);
        void CreateBooks_By_Author(Books_By_Author books_By_Author);
        void DeleteBooks_By_Author(Books_By_Author books_By_Author);
    }
}
