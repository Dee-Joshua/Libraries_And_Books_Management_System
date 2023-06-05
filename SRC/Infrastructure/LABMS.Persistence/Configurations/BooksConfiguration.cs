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
    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<Book> GenerateData(int count)
        {
            List<Book> data = new List<Book>();
            for (int i = 1; i <= count; i++)
            {
                Book book = new Book
                {
                    Isbn = i,
                    BookTitle = $"Book Title {i}",
                    Date_Of_Publication = DateTime.Now.AddDays(-i)
                };
                data.Add(book);
            }
            return data;
        }
    }
}
