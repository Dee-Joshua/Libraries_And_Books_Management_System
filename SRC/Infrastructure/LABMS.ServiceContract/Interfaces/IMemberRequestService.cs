using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Interfaces
{
    public interface IMemberRequestService
    {
        Task<IEnumerable<MemberRequestDto>> GetAllMemberRequestAsync(bool trackChanges);
        Task<MemberRequestDto> GetMemberRequestByIdAsync(int memberId, int id, bool trackChanges);
        Task<IEnumerable<MemberRequestDto>> GetAllMemberRequestByMemberId(int memberId, bool trackChanges);
        Task<IEnumerable<MemberRequestDto>> GetAllMemberRequestByBookId(int bookId, bool trackChanges);
        Task<IEnumerable<MemberRequestDto>> GetAllMemberRequestByLibraryId(int libraryId, bool trackChanges);
        Task<MemberRequestDto> CreateMemberRequest(MemberRequestForCreation memberRequestDto);// Need to also check if the quantity of book is not 0
        Task CloseMemberRequest(int memberId, int requestId);

    }
}
