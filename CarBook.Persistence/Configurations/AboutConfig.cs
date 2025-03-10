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
    public class AboutConfig : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.HasData(
                new About
                {
                    Id = 1,
                    Title = "Welcome to Carbook",
                    Description = "Welcome to CarBook, your ultimate destination for seamless car booking and rental services. Whether you're looking for a vehicle for a business trip, a weekend getaway, or daily commuting, CarBook provides a hassle-free experience with a wide selection of cars to suit your needs.  Our platform is designed with convenience in mind, offering easy online reservations, competitive pricing, and a user-friendly interface. We connect customers with trusted rental providers, ensuring reliability, safety, and transparency in every booking.  At CarBook, we prioritize customer satisfaction by providing detailed vehicle information, flexible booking options, and secure payment methods. Our goal is to make car rentals more accessible and stress-free, so you can focus on the journey ahead.  Book your car today and experience the road with confidence!",
                    ImageUrl = "website-template/images/about.jpg"
                }
            );
        }
    }
}
