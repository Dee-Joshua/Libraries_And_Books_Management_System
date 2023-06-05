using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IMember_Request_Repository
    {
        Task<IEnumerable<MemberRequest>> GetAllMemberRequestsAsync(bool trackChanges);
        Task<MemberRequest> GetMemberRequestByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<MemberRequest>> GetAllMemberRequestByLibraryId(int libraryId, bool trackChanges);  
        Task<IEnumerable<MemberRequest>> GetAllMemberRequestedByMemberId(int memberId, bool trackChanges);
        Task<IEnumerable<MemberRequest>> GetAllMemberRequestedByBookId(int bookId, bool trackChanges);
        void CreateMemberRequest(MemberRequest memberRequest);
        void DeleteMemberRequest(MemberRequest memberRequest);
    }
}
