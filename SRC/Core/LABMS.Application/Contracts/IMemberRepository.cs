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
        Task<Member> GetMemberByIdAsync(int Id, bool trackChanges);
        Task<Member> GetMemberByName(string FirstName, string LastName, bool trackchanges);
        Task<Member> GetMemberByEmail(string EmailAddress, bool trackchanges);
        void CreateMember(Member member);
        void DeleteMember(Member member);
    }
}
