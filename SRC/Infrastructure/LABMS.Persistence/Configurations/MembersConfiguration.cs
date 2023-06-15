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

    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<Member> GenerateData(int count)
        {
            List<Member> data = new List<Member>();
            for (int i = 1; i <= count; i++)
            {
                Member member = new Member
                {
                   MemberId = i,
                Gender = i % 2 == 0 ? "Male" : "Female",
                FirstName = $"First Name {i}",
                LastName = $"Last Name {i}",
                PhoneNumber = 1234567890 + i,
                EmailAddress = $"email{i}@example.com"
                };
                data.Add(member);
            }
            return data;
        }
    }
}
