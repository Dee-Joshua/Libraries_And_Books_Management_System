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

    public class AmazonBooksConfiguration : IEntityTypeConfiguration<AmazonBooks>
    {
        public void Configure(EntityTypeBuilder<AmazonBooks> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<AmazonBooks> GenerateData(int count)
        {
            List<AmazonBooks> data = new List<AmazonBooks>();
            for (int i = 1; i <= count; i++)
            {
                AmazonBooks amazon = new AmazonBooks
                {
                    Isbn = i,
                    Title = $"Book {i}",
                    Author = $"Author {i}",
                    Date_Of_Publication = DateTime.Now.AddDays(-i),
                    Amazon_Star_Rating = i % 6,
                    Publisher = $"Publisher {i}",
                    ListPrice = 10.99 * i,
                    AmazonPrice = 9.99 * i,
                    YourSaving = 1.00 * i
                };
                data.Add(amazon);
            }
            return data;
        }
    }
}
