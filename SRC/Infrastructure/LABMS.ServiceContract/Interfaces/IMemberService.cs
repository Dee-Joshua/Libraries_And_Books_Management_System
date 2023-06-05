using LABMS.Application.DTOs.ForCreation;
using LABMS.Application.DTOs.ForDto;
using LABMS.Application.DTOs.ForUpdate;
using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.ServiceContract.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberDto>> GetAllMembersAsync(bool trackChanges);
        Task<MemberDto> GetMemberById(int memberId, bool trackChanges);
        MemberDto CreateMember(MemberForCreation member);
        Task UpdateMember(MemberForUpdate member);
        Task DeleteMember(int memberId);
    }
}
