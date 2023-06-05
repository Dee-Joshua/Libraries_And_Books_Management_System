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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<Author> GenerateData(int count)
        {
            List<Author> data = new List<Author>();
            for (int i = 1; i <= count; i++)
            {
                Author author = new Author
                {
                    AuthorId = i,
                    FirstName = $"First Name {i}",
                    LastName = $"Last Name {i}"
                };
                data.Add(author);
            }
            return data;
        }
    }
}
