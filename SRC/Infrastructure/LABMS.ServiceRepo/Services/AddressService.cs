using AutoMapper;
using LABMS.Application.Common;
using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using LABMS.Application.Exceptions;
using LABMS.Domain.entities;
using LABMS.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceRepository.Services
{
    public class AddressService : IAddressService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public AddressService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<AddressDto> CreateAddressAsync(int id, AddressForCreationDto addressCreationDto)
        {
            var haveAddress = await _repositoryManager.AddressRepository.GetAddressByIdAsync(id, false);
            if (haveAddress != null)
            {
                throw new AddressAlreadyExistException(id);
            }
            var address = _mapper.Map<Address>(addressCreationDto);
            _repositoryManager.AddressRepository.CreateAddress(address);
            await _repositoryManager.SaveAsync();
            var addressDto = _mapper.Map<AddressDto>(address);
            return addressDto;
        }

        public async Task DeleteAddressAsync(int id, bool trackChanges)
        {
            var address = await CheckIfAddressExistAndReturnAddress(id, trackChanges);
            _repositoryManager.AddressRepository.DeleteAddress(address);
            await _repositoryManager.SaveAsync();
        }

        public async Task<AddressDto> GetAddressAsync(int baseId, bool trackChanges)
        {
            var address = await CheckIfAddressExistAndReturnAddress(baseId, trackChanges);
            var addressDto = _mapper.Map<AddressDto>(address);
            return addressDto;
        }

        public async Task UpdateAddressAsync(AddressForUpdate addressUpdateDto, bool trackChanges)
        {
            await CheckIfAddressExistAndReturnAddress(addressUpdateDto.BaseId, trackChanges);
            var addressToUpdate = _mapper.Map<Address>(addressUpdateDto);
            _repositoryManager.AddressRepository.UpdateAddress(addressToUpdate);
            await _repositoryManager.SaveAsync();
        }

        //private methods to check if address exists and return the value 
        //Reusable codes
        private async Task<Address> CheckIfAddressExistAndReturnAddress(int id, bool trackChanges)
        {
            var address = await _repositoryManager.AddressRepository.GetAddressByIdAsync(id, trackChanges)
                ?? throw new AddressNotFoundException(id);
            return address;
        }
    }
}
