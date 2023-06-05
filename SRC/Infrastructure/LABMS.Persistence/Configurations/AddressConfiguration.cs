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
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData
                 (
                     GenerateData(10)
                 );
        }

        private List<Address> GenerateData(int count)
        {
            List<Address> data = new List<Address>();
            for (int i = 1; i <= count; i++)
            {
                Address address = new Address
                {
                    BaseId = i,
                    BuildingNumber = $"Building {i}",
                    StreetName = $"Street {i}",
                    AreaLocality = $"Area {i}",
                    State = $"State {i}",
                    Country = $"Country {i}"
                };
                data.Add(address);
            }
            return data;
        }
    }
}
