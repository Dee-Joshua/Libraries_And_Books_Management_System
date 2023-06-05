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
    public class MemberService : IMemberService
    {
        protected readonly IRepositoryManager _repositoryManager;
        protected readonly IMapper _mapper;
        public MemberService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public MemberDto CreateMember(MemberForCreation member)
        {
            var memberModel = _mapper.Map<Member>(member);
            _repositoryManager.MemberRepository.CreateMember(memberModel);
            var memberDto = _mapper.Map<MemberDto>(memberModel);
            return memberDto;
        }

        public async Task DeleteMember(int memberId)
        {
            var member = await _repositoryManager.MemberRepository.GetMemberByIdAsync(memberId, false) ?? throw new MemberNotFoundException(memberId);
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
            var member = await _repositoryManager.MemberRepository.GetMemberByIdAsync(memberId, trackChanges) 
                ?? throw new MemberNotFoundException(memberId);
            var memberDto = _mapper.Map<MemberDto>(member);
            return memberDto;
        }

        public async Task UpdateMember(MemberForUpdate memberForUpdate)
        {
            var member = await _repositoryManager.MemberRepository
                .GetMemberByIdAsync(memberForUpdate.MemberId, false)
                ?? throw new MemberNotFoundException(memberForUpdate.MemberId);
            member = _mapper.Map<Member>(memberForUpdate);
            _repositoryManager.MemberRepository.UpdateMember(member);
            await _repositoryManager.SaveAsync();
        }
    }
}
