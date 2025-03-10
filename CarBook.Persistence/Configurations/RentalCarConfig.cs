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
    public class RentalCarConfig : IEntityTypeConfiguration<RentalCar>
    {
        public void Configure(EntityTypeBuilder<RentalCar> builder)
        {
            builder.HasData(
                new RentalCar
                {
                    Id = 1,
                    CarId = 1,
                    LocationId = 1,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 2,
                    CarId = 2,
                    LocationId = 2,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 3,
                    CarId = 3,
                    LocationId = 3,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 4,
                    CarId = 4,
                    LocationId = 4,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 5,
                    CarId = 5,
                    LocationId = 5,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 6,
                    CarId = 6,
                    LocationId = 6,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 7,
                    CarId = 7,
                    LocationId = 1,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 8,
                    CarId = 8,
                    LocationId = 2,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 9,
                    CarId = 9,
                    LocationId = 3,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 10,
                    CarId = 10,
                    LocationId = 4,
                    IsAvailable = true,
                },
                new RentalCar
                {
                    Id = 11,
                    CarId = 11,
                    LocationId = 5,
                    IsAvailable = true,
                }
            );
        }
    }
}
