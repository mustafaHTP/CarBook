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
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { Id = 1, Name = "Ford" },
                new Brand { Id = 2, Name = "Mercedes" },
                new Brand { Id = 3, Name = "Range Rover" },
                new Brand { Id = 4, Name = "McLaren" },
                new Brand { Id = 5, Name = "BMW" },
                new Brand { Id = 6, Name = "Alfa Romeo" },
                new Brand { Id = 7, Name = "Jeep" },
                new Brand { Id = 8, Name = "Audi" }
                );
        }
    }
}
