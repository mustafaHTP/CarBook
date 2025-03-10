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
    public class ContactConfig : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasData(
                new Contact
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "john.doe@example.com",
                    Subject = "Booking Inquiry - Sedan",
                    Message = "I would like to inquire about booking a sedan for a weekend trip. Please let me know the availability and pricing details.",
                    SendDate = new DateTime(2024, 10, 22, 5, 25, 0)
                },
                new Contact
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Subject = "Car Rental Request - SUV",
                    Message = "I'm interested in renting an SUV for a family vacation next month. Could you provide information on availability and the rental terms?",
                    SendDate = new DateTime(2024, 11, 27, 13, 35, 0)
                }
            );
        }
    }
}
