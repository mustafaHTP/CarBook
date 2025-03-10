using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Configurations
{
    public class FooterAddressConfig : IEntityTypeConfiguration<FooterAddress>
    {
        public void Configure(EntityTypeBuilder<FooterAddress> builder)
        {
            builder.HasData(
                new FooterAddress
                {
                    Id = 1,
                    Description = "Carbook - Your go-to platform for all things related to cars, from buying to selling and beyond.",
                    Address = "123 Auto Lane, Car City, CC 12345, USA",
                    Email = "contact@carbook.com",
                    Phone = "+1 123 456 7890"
                }
            );
        }
    }
}
