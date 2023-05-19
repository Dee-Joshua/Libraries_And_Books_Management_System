using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAllAddressesAsync(bool trackChanges);
        Task<Address> GetAddressByIdAsync(int Id, bool trackChanges);
        Task<Address> GetAddressByName(string BuildingNumber, string StreetName, bool trackchanges);
        void CreateAddress(Address address);
        void DeleteAddress(Address address);
    }
}
