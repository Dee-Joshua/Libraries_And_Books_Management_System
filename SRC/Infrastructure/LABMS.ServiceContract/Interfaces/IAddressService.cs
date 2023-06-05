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
        //Task<IEnumerable<AddressDto>> GetAllAddressesAsync(bool trackChanges);//We need to review this function..
        Task<AddressDto> GetAddressAsync(int baseId, bool trackChanges);
        Task<AddressDto> CreateAddressAsync(AddressForCreation addressCreationDto, bool trackChanges);//Remove trackChanges
        Task UpdateAddressAsync(AddressForUpdate addressUpdateDto, bool trackChanges);//Remove trackChanges
        Task DeleteAddressAsync(int id, bool trackChanges);//Remove trackChanges
    }
}
