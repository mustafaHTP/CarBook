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
    public class ModelConfig : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasData(
                new Model { Id = 1, BrandId = 1, Name = "GT500" },
                new Model { Id = 2, BrandId = 2, Name = "SLK55" },
                new Model { Id = 3, BrandId = 4, Name = "P1" },
                new Model { Id = 4, BrandId = 3, Name = "Evoque" },
                new Model { Id = 5, BrandId = 5, Name = "M3" },
                new Model { Id = 6, BrandId = 6, Name = "8C Spider" },
                new Model { Id = 7, BrandId = 2, Name = "CLE 300" },
                new Model { Id = 8, BrandId = 7, Name = "Wrangler Rubicon" },
                new Model { Id = 9, BrandId = 2, Name = "GT Coupe" },
                new Model { Id = 10, BrandId = 2, Name = "A180" },
                new Model { Id = 11, BrandId = 8, Name = "A1" }
                );
        }
    }
}
