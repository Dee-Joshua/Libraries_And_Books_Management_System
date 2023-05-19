using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetBookByIdAsync(int Id, bool trackChanges);
        Task<Book> GetBookByTitle(string BookTitle, bool trackchanges);
        void CreateBook(Book book);
        void DeleteBook(Book book);
    }
}
