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
    public class BlogCategoryConfig : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasData(
                new BlogCategory { Id = 1, Name = "Car Trends" },
                new BlogCategory { Id = 2, Name = "Car Technology" },
                new BlogCategory { Id = 3, Name = "Electric Car" },
                new BlogCategory { Id = 4, Name = "Car Cleaning" }
                );
        }
    }
}
