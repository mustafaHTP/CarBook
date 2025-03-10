using CarBook.Domain.Entities;
using CarBook.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CarBook.Persistence.Configurations
{
    public class CarConfig : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new Car
                {
                    Id = 1,
                    ModelId = 1,
                    Km = 250,
                    SeatCount = 2,
                    Luggage = 2,
                    TransmissionType = TransmissionType.Manual,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-4.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 2,
                    ModelId = 2,
                    Km = 50,
                    SeatCount = 2,
                    Luggage = 3,
                    TransmissionType = TransmissionType.Automatic,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-1.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 3,
                    ModelId = 3,
                    Km = 0,
                    SeatCount = 2,
                    Luggage = 1,
                    TransmissionType = TransmissionType.Automatic,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-3.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 4,
                    ModelId = 4,
                    Km = 1000,
                    SeatCount = 4,
                    Luggage = 6,
                    TransmissionType = TransmissionType.Automatic,
                    FuelType = FuelType.Diesel,
                    CoverImageUrl = "/website-template/images/car-2.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 5,
                    ModelId = 5,
                    Km = 100,
                    SeatCount = 4,
                    Luggage = 4,
                    TransmissionType = TransmissionType.Manual,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-5.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 6,
                    ModelId = 6,
                    Km = 0,
                    SeatCount = 2,
                    Luggage = 2,
                    TransmissionType = TransmissionType.Automatic,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-6.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 7,
                    ModelId = 7,
                    Km = 0,
                    SeatCount = 2,
                    Luggage = 2,
                    TransmissionType = TransmissionType.Manual,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-7.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 8,
                    ModelId = 8,
                    Km = 850,
                    SeatCount = 4,
                    Luggage = 6,
                    TransmissionType = TransmissionType.Automatic,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-8.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 9,
                    ModelId = 9,
                    Km = 0,
                    SeatCount = 2,
                    Luggage = 1,
                    TransmissionType = TransmissionType.Manual,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-10.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 10,
                    ModelId = 10,
                    Km = 800,
                    SeatCount = 4,
                    Luggage = 4,
                    TransmissionType = TransmissionType.Automatic,
                    FuelType = FuelType.Diesel,
                    CoverImageUrl = "/website-template/images/car-11.jpg",
                    BigImageUrl = "/bigImageUrl"
                },
                new Car
                {
                    Id = 11,
                    ModelId = 11,
                    Km = 1249,
                    SeatCount = 4,
                    Luggage = 4,
                    TransmissionType = TransmissionType.Manual,
                    FuelType = FuelType.Petrol,
                    CoverImageUrl = "/website-template/images/car-12.jpg",
                    BigImageUrl = "/bigImageUrl"
                }
            );

        }
    }
}
