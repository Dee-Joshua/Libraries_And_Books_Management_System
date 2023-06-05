using AutoMapper;
using LABMS.Application.Common;
using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
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
    public class Member_RequestService : IMemberRequestService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public Member_RequestService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public async Task CloseMemberRequest(int requestId)
        {
            var memberRequest = await _repositoryManager.MemberRequestRepository
                .GetMemberRequestByIdAsync(requestId, false)
                ?? throw new MemberRequestNotFoundException(requestId);
            var itemInStock = await _repositoryManager.BooksAtLibraryRepository
                .GetBooks_At_LibraryByIdAsync(memberRequest.Isbn, memberRequest.LibraryId, false)
                ?? throw new Book_At_LibraryNotFoundException(memberRequest.Isbn, memberRequest.LibraryId);

            _repositoryManager.MemberRequestRepository.DeleteMemberRequest(memberRequest);
            itemInStock.Quantity_In_Stock++;
            _repositoryManager.BooksAtLibraryRepository.UpdateBook_At_Library(itemInStock);
            await _repositoryManager.SaveAsync();
        }

        public async Task<MemberRequestDto> CreateMemberRequest(MemberRequestForCreation memberRequest)
        {
            var itemInStock = await _repositoryManager.BooksAtLibraryRepository
                .GetBooks_At_LibraryByIdAsync(memberRequest.Isbn, memberRequest.LibraryId, false)
                ?? throw new Book_At_LibraryNotFoundException(memberRequest.Isbn, memberRequest.LibraryId);
            if(itemInStock.Quantity_In_Stock is 0)
            {
                throw new BookOutOfStockException(memberRequest.Isbn, memberRequest.LibraryId);
            }
            var memberRequestCreate= _mapper.Map<MemberRequest> (memberRequest);
            _repositoryManager.MemberRequestRepository.CreateMemberRequest(memberRequestCreate);
            itemInStock.Quantity_In_Stock--;
            _repositoryManager.BooksAtLibraryRepository.UpdateBook_At_Library(itemInStock);
            await _repositoryManager .SaveAsync();
            var memberRequestDto = _mapper.Map<MemberRequestDto>(memberRequestCreate);
            return memberRequestDto;
        }

        public async Task<IEnumerable<MemberRequestDto>> GetAllMemberRequestAsync(bool trackChanges)
        {
            var memberRequests = await _repositoryManager.MemberRequestRepository
                .GetAllMemberRequestsAsync(trackChanges)
                ?? throw new MemberRequestNotFoundException();
            var memberRequestsDto = _mapper.Map<IEnumerable<MemberRequestDto>>(memberRequests);
            return memberRequestsDto;
        }

        public async Task<IEnumerable<MemberRequestDto>> GetAllMemberRequestByBookId(int bookId, bool trackChanges)
        {
            var memberRequest = await _repositoryManager.MemberRequestRepository
                .GetAllMemberRequestedByBookId(bookId, trackChanges)
                ?? throw new MemberRequestNotFoundException(bookId);
            var memberRequestDto = _mapper.Map<IEnumerable<MemberRequestDto>>(memberRequest);
            return memberRequestDto;
        }

        public async Task<IEnumerable<MemberRequestDto>> GetAllMemberRequestByLibraryId(int libraryId, bool trackChanges)
        {
            var memberRequest = await _repositoryManager.MemberRequestRepository
                .GetAllMemberRequestByLibraryId(libraryId, trackChanges)
                ?? throw new MemberRequestNotFoundException(libraryId);
            var memberRequestDto = _mapper.Map<IEnumerable<MemberRequestDto>>(memberRequest);
            return memberRequestDto;
        }

        public async Task<IEnumerable<MemberRequestDto>> GetAllMemberRequestByMemberId(int memberId, bool trackChanges)
        {
            var memberRequest = await _repositoryManager.MemberRequestRepository
                .GetAllMemberRequestedByMemberId(memberId, trackChanges)
                ??throw new MemberRequestNotFoundException(memberId);
            var memberRequestDto = _mapper.Map<IEnumerable<MemberRequestDto>>(memberRequest);
            return memberRequestDto;
        }

        public async Task<MemberRequestDto> GetMemberRequestByIdAsync(int id, bool trackChanges)
        {
            var memberRequest = await _repositoryManager.MemberRequestRepository
                .GetMemberRequestByIdAsync(id, trackChanges)
                ?? throw new MemberNotFoundException(id);
            var memberRequestDto = _mapper.Map<MemberRequestDto>(memberRequest);
            return memberRequestDto;
        }
    }
}
