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
    public class TestimonialConfig : IEntityTypeConfiguration<Testimonial>
    {
        public void Configure(EntityTypeBuilder<Testimonial> builder)
        {
            builder.HasData(
                new Testimonial
                {
                    Id = 1,
                    Name = "Roger Scott",
                    Title = "Car Enthusiast",
                    Comment = "I've always had a passion for classic cars, and the way they combine craftsmanship and style is unmatched. The '67 Mustang will always be my favorite.",
                    ImageUrl = "/website-template/images/person_1.jpg"
                },
                new Testimonial
                {
                    Id = 2,
                    Name = "Emily Brown",
                    Title = "Automotive Engineer",
                    Comment = "Modern cars are a marvel of engineering, with all the tech and safety features. I’m fascinated by electric vehicles and how they’re changing the landscape of the industry.",
                    ImageUrl = "/website-template/images/person_2.jpg"
                },
                new Testimonial
                {
                    Id = 3,
                    Name = "John Doe",
                    Title = "Mechanic",
                    Comment = "There's nothing like the satisfaction of restoring an old car. The sound of a perfectly tuned engine is music to my ears.",
                    ImageUrl = "/website-template/images/person_3.jpg"
                },
                new Testimonial
                {
                    Id = 4,
                    Name = "Anna Smith",
                    Title = "Motorsport Journalist",
                    Comment = "I’ve been covering racing for over a decade. The speed, the skill, and the technology behind motorsport are absolutely thrilling to witness.",
                    ImageUrl = "/website-template/images/person_4.jpg"
                },
                new Testimonial
                {
                    Id = 5,
                    Name = "Michael Johnson",
                    Title = "Car Collector",
                    Comment = "For me, cars are more than just transportation. They represent history and craftsmanship. Owning a piece of automotive history, like a Ferrari 250 GTO, is a dream come true.",
                    ImageUrl = "/website-template/images/person_1.jpg"
                },
                new Testimonial
                {
                    Id = 6,
                    Name = "Sophia Davis",
                    Title = "Sustainability Advocate",
                    Comment = "I believe in the future of electric cars and their potential to transform our cities and reduce our carbon footprint. It’s exciting to see how fast the technology is advancing.",
                    ImageUrl = "/website-template/images/person_2.jpg"
                },
                new Testimonial
                {
                    Id = 7,
                    Name = "James Wilson",
                    Title = "Car Designer",
                    Comment = "Designing cars is about balancing aesthetics, functionality, and performance. It's thrilling to see the latest models on the road, knowing we had a hand in creating them.",
                    ImageUrl = "/website-template/images/person_3.jpg"
                }
            );
        }
    }
}
