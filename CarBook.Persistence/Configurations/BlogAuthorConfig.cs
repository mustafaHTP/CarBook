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
    public class BlogAuthorConfig : IEntityTypeConfiguration<BlogAuthor>
    {
        public void Configure(EntityTypeBuilder<BlogAuthor> builder)
        {
            builder.HasData(
                new BlogAuthor
                {
                    Id = 1,
                    Name = "John Doe",
                    Description = "John Doe is an experienced automotive journalist with a passion for performance cars and cutting-edge technology. With over a decade of writing about the latest in car reviews, industry trends, and innovations, he brings a unique perspective to the world of automotive content.",
                    ImageUrl = "/website-template/images/person_1.jpg"
                },
                new BlogAuthor
                {
                    Id = 2,
                    Name = "Robert Williams",
                    Description = "Robert Williams is a seasoned automotive writer with a passion for classic cars and vintage vehicles. With a keen eye for detail and a deep knowledge of automotive history, she brings a unique perspective to the world of car journalism.",
                    ImageUrl = "/website-template/images/person_2.jpg"
                }
            );
        }
    }
}
