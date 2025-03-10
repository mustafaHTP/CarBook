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
    public class CarReviewConfig : IEntityTypeConfiguration<CarReview>
    {
        public void Configure(EntityTypeBuilder<CarReview> builder)
        {
            builder.HasData(
                new CarReview
                {
                    Id = 1,
                    CarId = 1, // Mustang GT500
                    CustomerId = 1,
                    Review = "Amazing performance and design! The GT500 is a beast on the road.",
                    ReviewDate = new DateTime(2024, 2, 20),
                    RatingStarCount = 5
                },
                new CarReview
                {
                    Id = 2,
                    CarId = 2, // Mercedes-Benz SLK
                    CustomerId = 2,
                    Review = "Smooth drive, luxurious feel, but a bit expensive.",
                    ReviewDate = new DateTime(2024, 2, 18),
                    RatingStarCount = 4
                },
                new CarReview
                {
                    Id = 3,
                    CarId = 3, // McLaren P1
                    CustomerId = 3,
                    Review = "Absolutely stunning car, breathtaking speed and handling.",
                    ReviewDate = new DateTime(2024, 2, 15),
                    RatingStarCount = 5
                },
                new CarReview
                {
                    Id = 4,
                    CarId = 4, // Range Rover
                    CustomerId = 4,
                    Review = "Great for off-roading, very comfortable and stylish.",
                    ReviewDate = new DateTime(2024, 2, 12),
                    RatingStarCount = 4
                },
                new CarReview
                {
                    Id = 5,
                    CarId = 5, // BMW M3
                    CustomerId = 5,
                    Review = "Classic M3 experience—responsive and powerful.",
                    ReviewDate = new DateTime(2024, 2, 10),
                    RatingStarCount = 5
                },
                new CarReview
                {
                    Id = 6,
                    CarId = 6, // Alfa Romeo 8C Spider
                    CustomerId = 6,
                    Review = "A true beauty! The 8C Spider has a fantastic sound and feel.",
                    ReviewDate = new DateTime(2024, 2, 8),
                    RatingStarCount = 5
                },
                new CarReview
                {
                    Id = 7,
                    CarId = 7, // Mercedes CLE 300
                    CustomerId = 7,
                    Review = "A stylish, comfortable ride with plenty of features. Love the performance and handling!",
                    ReviewDate = new DateTime(2024, 2, 5),
                    RatingStarCount = 3
                },
                new CarReview
                {
                    Id = 8,
                    CarId = 8, // Jeep Rubicon
                    CustomerId = 8,
                    Review = "The ultimate adventure vehicle! Handles rough terrains like a pro.",
                    ReviewDate = new DateTime(2024, 2, 2),
                    RatingStarCount = 5
                },
                new CarReview
                {
                    Id = 9,
                    CarId = 9, // Mercedes-AMG GT
                    CustomerId = 9,
                    Review = "Great performance but a little overpriced.",
                    ReviewDate = new DateTime(2024, 1, 30),
                    RatingStarCount = 4
                },
                new CarReview
                {
                    Id = 10,
                    CarId = 10, // Mercedes A180
                    CustomerId = 10,
                    Review = "Compact and stylish, perfect for city driving.",
                    ReviewDate = new DateTime(2024, 1, 28),
                    RatingStarCount = 5
                },
                new CarReview
                {
                    Id = 11,
                    CarId = 11, // Audi A1
                    CustomerId = 10,
                    Review = "Compact, efficient, and fun to drive. A great city car, but could use a bit more power.",
                    ReviewDate = new DateTime(2024, 1, 28),
                    RatingStarCount = 4
                }
            );

        }
    }
}
