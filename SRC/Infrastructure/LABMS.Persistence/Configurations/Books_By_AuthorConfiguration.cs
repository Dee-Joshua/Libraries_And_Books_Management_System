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
    public class Books_By_AuthorConfiguration : IEntityTypeConfiguration<Books_By_Author>
    {
        public void Configure(EntityTypeBuilder<Books_By_Author> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<Books_By_Author> GenerateData(int count)
        {
            List<Books_By_Author> data = new List<Books_By_Author>();
            for (int i = 1; i <= count; i++)
            {
                Books_By_Author books_By_Author = new Books_By_Author
                {
                    AuthorId = i,
                    Isbn = i
                };
                data.Add(books_By_Author);
            }
            return data;
        }
    }
}
