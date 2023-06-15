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
    internal sealed class Amazon_Books_Repository : RepositoryBase<AmazonBooks>, IAmazon_Books_Repository
    {
        public Amazon_Books_Repository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateAmazonBooks(AmazonBooks amazonBooks) => Create(amazonBooks);

        public void DeleteAmazonBooks(AmazonBooks amazonBooks) => Delete(amazonBooks);

        public async Task<IEnumerable<AmazonBooks>> GetAllAmazonBooksAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.Isbn)
                .ToListAsync();
        }

        public async Task<AmazonBooks> GetAmazonBooksByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.Isbn.Equals(id), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<AmazonBooks> GetAmazonBooksByTitle(string title, bool trackChanges)
        {
            return await FindByCondition(x => x.Title.Contains(title), trackChanges).FirstOrDefaultAsync();
        }
    }
}
