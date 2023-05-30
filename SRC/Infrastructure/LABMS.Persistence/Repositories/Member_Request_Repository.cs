﻿using LABMS.Application.Contracts;
using LABMS.Domain.entities;
using LABMS.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Persistence.Repositories
{
    internal sealed class Member_Request_Repository : RepositoryBase<MemberRequest>, IMember_Request_Repository
    {
        public Member_Request_Repository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateMemberRequest(MemberRequest memberRequest) => Create(memberRequest);

        public void DeleteMemberRequest(MemberRequest memberRequest) => Delete(memberRequest);

        public async Task<IEnumerable<MemberRequest>> GetAllMemberRequestsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(x => x.RequestId)
                .ToListAsync();
        }

        public async Task<MemberRequest> GetMemberRequestByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(x => x.RequestId.Equals(id), trackChanges).FirstOrDefaultAsync();
        }
    }
}
