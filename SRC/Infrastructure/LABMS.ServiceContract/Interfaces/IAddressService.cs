using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressDto>> GetAllAddressesAsync(bool trackChanges);
        Task<AddressDto> GetAddressAsync(int id, bool trackChanges);
        Task<AddressDto> CreateAddressAsync(AddressForCreation addressCreationDto, bool trackChanges);
        Task UpdateAddressAsync(int id, AddressForUpdate addressUpdateDto, bool trackChanges);
        Task DeleteAddressAsync(int id, bool trackChanges);
    }
}
