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
    public class BlogTagCloudConfig : IEntityTypeConfiguration<BlogTagCloud>
    {
        public void Configure(EntityTypeBuilder<BlogTagCloud> builder)
        {
            builder.HasData(
                new BlogTagCloud
                {
                    Id = 1,
                    BlogTagId = 1, // History
                    BlogId = 1, // Car History
                },
                new BlogTagCloud
                {
                    Id = 2,
                    BlogTagId = 4, // Interesting
                    BlogId = 1, // Car History
                },
                new BlogTagCloud
                {
                    Id = 3,
                    BlogTagId = 2, // Tech
                    BlogId = 3, // The Evolution of Electric Cars
                },
                new BlogTagCloud
                {
                    Id = 4,
                    BlogTagId = 5, // Future of Cars
                    BlogId = 3, // The Evolution of Electric Cars
                },
                new BlogTagCloud
                {
                    Id = 5,
                    BlogTagId = 3, // Trend
                    BlogId = 3, // The Evolution of Electric Cars
                },
                new BlogTagCloud
                {
                    Id = 6,
                    BlogTagId = 6, // Concept Cars
                    BlogId = 1, // Car History
                },
                new BlogTagCloud
                {
                    Id = 7,
                    BlogTagId = 7, // Hybrid Cars
                    BlogId = 3, // The Evolution of Electric Cars
                },
                new BlogTagCloud
                {
                    Id = 8,
                    BlogTagId = 8, // Iconic
                    BlogId = 2, // Formula 1 Accident
                }
            );
        }
    }
}
