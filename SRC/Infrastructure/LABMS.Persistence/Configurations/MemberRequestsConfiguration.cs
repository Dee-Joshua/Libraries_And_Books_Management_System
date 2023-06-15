using LABMS.Domain.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABMS.Persistence.Configurations
{
    public class MemberRequestsConfiguration : IEntityTypeConfiguration<MemberRequest>
    {
        public void Configure(EntityTypeBuilder<MemberRequest> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<MemberRequest> GenerateData(int count)
        {
            List<MemberRequest> data = new List<MemberRequest>();
            for (int i = 1; i <= count; i++)
            {
                MemberRequest memberRequest = new MemberRequest()
                {
                    RequestId = i,
                    MemberId = i,
                    LibraryId = i,
                    Isbn = i,
                    DateRequested = DateTime.Now.AddDays(-i),
                    DateLocated = DateTime.Now.AddDays(-i)
                };
                data.Add(memberRequest);
            }
            return data;
        }
    }
}
