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
    internal sealed class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext repositoryContext): base(repositoryContext)
        {
            
        }

        public void CreateAddress(Address address) => Create(address);

        public void DeleteAddress(Address address) => Delete(address);

        public async Task<Address> GetAddressByIdAsync(int Id, bool trackChanges)
        {
            return await FindByCondition(x => x.AddressId.Equals(Id), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.AddressId)
                .ToListAsync();
        }
    }
}
