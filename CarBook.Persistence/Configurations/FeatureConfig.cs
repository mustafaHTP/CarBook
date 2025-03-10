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
    public class FeatureConfig : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasData(
                new Feature { Id = 1, Name = "ABS" },
                new Feature { Id = 2, Name = "Airbag" },
                new Feature { Id = 3, Name = "Wifi" },
                new Feature { Id = 4, Name = "GPS" },
                new Feature { Id = 5, Name = "Car Kit" },
                new Feature { Id = 6, Name = "Seat Belt" },
                new Feature { Id = 7, Name = "Child Seat" },
                new Feature { Id = 8, Name = "Bluetooth" },
                new Feature { Id = 9, Name = "Onboard Computer" },
                new Feature { Id = 10, Name = "Remote central locking" },
                new Feature { Id = 11, Name = "Music" },
                new Feature { Id = 12, Name = "Climate control" },
                new Feature { Id = 13, Name = "Airconditions" }
                );
        }
    }
}
