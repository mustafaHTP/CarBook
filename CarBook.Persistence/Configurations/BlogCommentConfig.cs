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
    public class BlogCommentConfig : IEntityTypeConfiguration<BlogComment>
    {
        public void Configure(EntityTypeBuilder<BlogComment> builder)
        {
            builder.HasData(
                new BlogComment
                {
                    Id = 1,
                    Name = "John Doe",
                    CreatedDate = new DateTime(2024, 1, 1, 12, 0, 0),
                    Content = "The history of cars is fascinating! It's amazing to see how far we've come in such a short time. I’m curious about the future developments in car technology.",
                    Email = "johndoe@email.com",
                    BlogId = 1,
                },
                new BlogComment
                {
                    Id = 2,
                    Name = "Jane Smith",
                    CreatedDate = new DateTime(2024, 2, 5, 14, 30, 0),
                    Content = "Formula 1 accidents are terrifying. The risks drivers face are unimaginable, and it's always shocking to see how they walk away from such crashes.",
                    Email = "janesmith@email.com",
                    BlogId = 2,
                },
                new BlogComment
                {
                    Id = 3,
                    Name = "Carlos Rivera",
                    CreatedDate = new DateTime(2024, 3, 10, 9, 15, 0),
                    Content = "Electric cars are definitely the future. The advancements in battery technology make them more practical than ever. It's great to see the industry moving towards sustainability.",
                    Email = "carlosrivera@email.com",
                    BlogId = 3,
                },
                new BlogComment
                {
                    Id = 4,
                    Name = "Sarah Lee",
                    CreatedDate = new DateTime(2024, 4, 15, 18, 45, 0),
                    Content = "The development of electric vehicles is impressive. It’s exciting to think about the impact these cars will have on the environment and the way we drive.",
                    Email = "sarahlee@email.com",
                    BlogId = 3,
                },
                new BlogComment
                {
                    Id = 5,
                    Name = "Mike Johnson",
                    CreatedDate = new DateTime(2024, 5, 20, 22, 10, 0),
                    Content = "Formula 1 accidents may be common, but they always leave a lasting impression. Every time something happens, it makes you appreciate the skill and bravery of the drivers even more.",
                    Email = "mikejohnson@email.com",
                    BlogId = 2,
                },
                new BlogComment
                {
                    Id = 6,
                    Name = "Emily Green",
                    CreatedDate = new DateTime(2024, 6, 25, 7, 5, 0),
                    Content = "I’ve always been fascinated by how electric vehicles have evolved. The shift from fossil fuels to electricity is one of the most important movements in the auto industry.",
                    Email = "emilygreen@email.com",
                    BlogId = 3,
                }
            );

        }
    }
}
