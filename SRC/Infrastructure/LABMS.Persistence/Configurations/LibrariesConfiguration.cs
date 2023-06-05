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
    public class LibrariesConfiguration : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<Library> GenerateData(int count)
        {
            List<Library> data = new List<Library>();
            for (int i = 1; i <= count; i++)
            {
                Library library = new Library
                {
                    LibraryId = i,
                    LibraryName = $"Library {i}",
                    LibraryDetails = $"Library Details {i}"
                };
                data.Add(library);
            }
            return data;
        }
    }
}
