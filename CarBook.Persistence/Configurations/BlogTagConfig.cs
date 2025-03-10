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
    public class BlogTagConfig : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            builder.HasData(
                new BlogTag { Id = 1, Name = "History" },
                new BlogTag { Id = 2, Name = "Tech" },
                new BlogTag { Id = 3, Name = "Trend" },
                new BlogTag { Id = 4, Name = "Interesting" },
                new BlogTag { Id = 5, Name = "Future of Cars" },
                new BlogTag { Id = 6, Name = "Concept Cars" },
                new BlogTag { Id = 7, Name = "Hybrid Cars" },
                new BlogTag { Id = 8, Name = "Iconic" }
             );
        }
    }
}
