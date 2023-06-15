using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IAmazon_Books_Repository
    {
        Task<IEnumerable<AmazonBooks>> GetAllAmazonBooksAsync(bool trackChanges);
        Task<AmazonBooks> GetAmazonBooksByIdAsync(int id, bool trackChanges);
        Task<AmazonBooks> GetAmazonBooksByTitle(string title, bool trackChanges);
        void CreateAmazonBooks(AmazonBooks amazonBooks);
        void DeleteAmazonBooks(AmazonBooks amazonBooks);
    }
}
