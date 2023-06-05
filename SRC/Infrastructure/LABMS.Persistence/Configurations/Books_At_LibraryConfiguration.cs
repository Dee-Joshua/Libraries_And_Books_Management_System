using LABMS.Domain.entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace LABMS.Persistence.Configurations
{
    public class Books_At_LibraryConfiguration : IEntityTypeConfiguration<Books_At_Library>
    {
        public void Configure(EntityTypeBuilder<Books_At_Library> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<Books_At_Library> GenerateData(int count)
        {
            List<Books_At_Library> data = new List<Books_At_Library>();
            for (int i = 1; i <= count; i++)
            {
                Books_At_Library books_At_Library = new Books_At_Library
                {
                    LibraryId = i,
                    Isbn = i,
                    Quantity_In_Stock = i * 5
                };
                data.Add(books_At_Library);
            }
            return data;
        }
    }
}
