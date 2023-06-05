using LABMS.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Application.Contracts
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMembersAsync(bool trackChanges);
        Task<Member> GetMemberByIdAsync(int id, bool trackChanges);
        Task<Member> GetMemberByPhoneNumber(int phoneNumber, bool trackChanges);
        Task<Member> GetMemberByEmail(string emailAddress, bool trackChanges);
        void CreateMember(Member member);
        void UpdateMember(Member member);
        void DeleteMember(Member member);
    }
}
