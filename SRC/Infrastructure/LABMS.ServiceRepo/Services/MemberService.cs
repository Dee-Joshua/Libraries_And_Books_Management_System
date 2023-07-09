using AutoMapper;
using LABMS.Application.Common;
using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using LABMS.Application.Exceptions;
using LABMS.Domain.entities;
using LABMS.ServiceContract.Interfaces;
using System;

namespace LABMS.ServiceRepository.Services
{
    public class MemberService : IMemberService
    {
        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IMapper _mapper;
        public MemberService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task<MemberDto> CreateMember(MemberForCreationDto member)
        {
            var memberModel = _mapper.Map<Member>(member);
            _repositoryManager.MemberRepository.CreateMember(memberModel);
            var address = memberModel.Address;
            if (address != null)
            {
                address.BaseId = memberModel.MemberId;
                _repositoryManager.AddressRepository.CreateAddress(address);
            }
            await _repositoryManager.SaveAsync();
            var memberDto = _mapper.Map<MemberDto>(memberModel);
            return memberDto;
        }

        public async Task DeleteMember(int memberId)
        {
            var member = await CheckIfMemberExistAndReturnMember(memberId, false);
            /*var address = await _repositoryManager.AddressRepository.GetAddressByIdAsync(memberId, false);
            if(address != null)
            {
                _repositoryManager.AddressRepository.DeleteAddress(address);
            }*/
            _repositoryManager.MemberRepository.DeleteMember(member);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<MemberDto>> GetAllMembersAsync(bool trackChanges)
        {
            var members = await _repositoryManager.MemberRepository.GetAllMembersAsync(trackChanges);
            var membersDto = _mapper.Map<IEnumerable<MemberDto>>(members);
            return membersDto;
        }

        public async Task<MemberDto> GetMemberById(int memberId, bool trackChanges)
        {
            var member = await CheckIfMemberExistAndReturnMember(memberId, trackChanges);
            var address = await _repositoryManager.AddressRepository.GetAddressByIdAsync(memberId, false);
            if(address != null)
            {
                member.Address = address;
            }
            var memberDto = _mapper.Map<MemberDto>(member);
            return memberDto;
        }

        public async Task UpdateMember(MemberForUpdate memberForUpdate)
        {
            var member = await CheckIfMemberExistAndReturnMember(memberForUpdate.MemberId, false);
            member = _mapper.Map<Member>(memberForUpdate);
            _repositoryManager.MemberRepository.UpdateMember(member);
            await _repositoryManager.SaveAsync();
        }

        //private methods to check if address exists and return the value 
        //Reusable codes
        private async Task<Member> CheckIfMemberExistAndReturnMember(int id, bool trackChanges)
        {
            var member = await _repositoryManager.MemberRepository.GetMemberByIdAsync(id, false) 
                ?? throw new MemberNotFoundException(id);
            return member;
        }
    }
}
