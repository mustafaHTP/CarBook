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
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasData(
                new Service
                {
                    Id = 1,
                    Title = "Airport Transfer",
                    Description = "Convenient rides to and from the airport with timely pickups and drop-offs.",
                    IconUrl = "flaticon-route"
                },
                new Service
                {
                    Id = 2,
                    Title = "City Tour",
                    Description = "Explore the city's landmarks and attractions with personalized car tours.",
                    IconUrl = "flaticon-transportation"
                },
                new Service
                {
                    Id = 3,
                    Title = "Outstation Rides",
                    Description = "Plan your long-distance journeys with comfortable and reliable outstation cabs.",
                    IconUrl = "flaticon-route"
                },
                new Service
                {
                    Id = 4,
                    Title = "Luxury Cars",
                    Description = "Travel in style and comfort with our premium car selection.",
                    IconUrl = "flaticon-suv"
                },
                new Service
                {
                    Id = 5,
                    Title = "Hourly Rentals",
                    Description = "Book a car with a driver for a flexible duration, charged on an hourly basis.",
                    IconUrl = "flaticon-car"
                },
                new Service
                {
                    Id = 6,
                    Title = "Event Transport",
                    Description = "Seamless transportation for weddings, parties, and other special occasions.",
                    IconUrl = "flaticon-route"
                },
                new Service
                {
                    Id = 7,
                    Title = "School Pickup and Drop",
                    Description = "Safe and reliable transportation services for students.",
                    IconUrl = "flaticon-backpack"
                },
                new Service
                {
                    Id = 8,
                    Title = "Corporate Travel",
                    Description = "Professional transportation solutions for your business travel needs.",
                    IconUrl = "flaticon-handshake"
                }
            );
        }
    }
}
