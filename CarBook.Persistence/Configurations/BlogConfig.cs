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
    public class BlogConfig : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasData(
                new Blog
                {
                    Id = 1,
                    Title = "Car History",
                    Content = "The history of cars is a long and interesting one. It all started with the invention of the wheel, and has evolved into the modern vehicles we see on the road today.",
                    CoverImageUrl = "https://images.nationalgeographic.org/image/upload/t_edhub_resource_key_image/v1638892232/EducationHub/photos/packard-model-b-automobile.jpg",
                    CreatedDate = new DateTime(2024, 7, 30, 16, 20, 0),
                    Description = "The history of cars is a long and interesting one.",
                    BlogAuthorId = 1,
                    BlogCategoryId = 2
                },
                new Blog
                {
                    Id = 2,
                    Title = "Formula 1 Accident",
                    Content = "Formula 1 is a dangerous sport, and accidents are a common occurrence. However, some accidents are more serious than others, and can have a lasting impact on the drivers involved.",
                    CoverImageUrl = "https://i.dunya.com/storage/files/images/2023/03/02/formula-1-YPIe_cover.jpg",
                    CreatedDate = new DateTime(2024, 8, 12, 11, 55, 0),
                    Description = "Formula 1 is a dangerous sport, and accidents are a common occurrence.",
                    BlogAuthorId = 2,
                    BlogCategoryId = 1
                },
                new Blog
                {
                    Id = 3,
                    Title = "The Evolution of Electric Cars",
                    Content = "Electric vehicles (EVs) have come a long way from their early prototypes to the modern, high-performance machines we see today. Advances in battery technology, charging infrastructure, and sustainability efforts have made EVs a practical choice for consumers worldwide.",
                    CoverImageUrl = "https://www.currencytransfer.com/wp-content/uploads/2022/11/ev-2-edit.min_.jpg",
                    CreatedDate = new DateTime(2024, 9, 17, 20, 40, 0),
                    Description = "A look at how electric cars have evolved and their impact on the automotive industry.",
                    BlogAuthorId = 1,
                    BlogCategoryId = 2
                }
            );
        }
    }
}
