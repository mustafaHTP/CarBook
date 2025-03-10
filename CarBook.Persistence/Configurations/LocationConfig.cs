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
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location { Id = 1, Name = "Los Angeles International Airport (LAX)" },
                new Location { Id = 2, Name = "John F. Kennedy International Airport (JFK)" },
                new Location { Id = 3, Name = "O'Hare International Airport (ORD)" },
                new Location { Id = 4, Name = "Miami International Airport (MIA)" },
                new Location { Id = 5, Name = "Dallas/Fort Worth International Airport (DFW)" },
                new Location { Id = 6, Name = "Denver International Airport (DEN)" }
            );
        }
    }
}
