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
    internal sealed class LibraryRepository : RepositoryBase<Library>, ILibraryRepository
    {
        public LibraryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateLibrary(Library library) => Create(library);

        public void DeleteLibrary(Library library) => Delete(library);

        public async Task<IEnumerable<Library>> GetAllLibrariesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.LibraryId)
                .ToListAsync();
        }

        public async Task<Library> GetLibraryByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.LibraryId.Equals(id), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<Library> GetLibraryByName(string libraryName, bool trackChanges)
        {
            return await FindByCondition(x => x.LibraryName.Contains(libraryName), trackChanges).FirstOrDefaultAsync();
        }
    }
}
