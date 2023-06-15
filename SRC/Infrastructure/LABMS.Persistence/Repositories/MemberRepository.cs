using LABMS.Application.Contracts;
using LABMS.Domain.entities;
using LABMS.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Persistence.Repositories
{
    internal sealed class MemberRepository : RepositoryBase<Member>, IMemberRepository
    {
        public MemberRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMember(Member member) => Create(member);

        public void DeleteMember(Member member) => Delete(member);

        public async Task<IEnumerable<Member>> GetAllMembersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.MemberId)
                .ToListAsync();
        }

        public async Task<Member> GetMemberByEmail(string emailAddress, bool trackChanges)
        {
            return await FindByCondition(x => x.EmailAddress.Contains(emailAddress), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<Member> GetMemberByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.MemberId.Equals(id), trackChanges).FirstOrDefaultAsync();
        }

        public async Task<Member> GetMemberByPhoneNumber(int phoneNumber, bool trackChanges)
        {
            return await FindByCondition(x => x.PhoneNumber.Equals(phoneNumber), trackChanges).FirstOrDefaultAsync();
        }

        public void UpdateMember(Member member)
        {
            Update(member);
        }
    }
}
