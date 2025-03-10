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
    public class CarReservationPricingConfig : IEntityTypeConfiguration<CarReservationPricing>
    {
        public void Configure(EntityTypeBuilder<CarReservationPricing> builder)
        {
            builder.HasData(
                new CarReservationPricing { Id = 1, CarId = 1, RentalPeriodId = 1, Price = 30.00m },
                new CarReservationPricing { Id = 2, CarId = 1, RentalPeriodId = 2, Price = 150.00m },
                new CarReservationPricing { Id = 3, CarId = 1, RentalPeriodId = 3, Price = 600.00m },
                new CarReservationPricing { Id = 4, CarId = 2, RentalPeriodId = 1, Price = 45.00m },
                new CarReservationPricing { Id = 5, CarId = 2, RentalPeriodId = 2, Price = 250.00m },
                new CarReservationPricing { Id = 6, CarId = 2, RentalPeriodId = 3, Price = 550.00m },
                new CarReservationPricing { Id = 7, CarId = 3, RentalPeriodId = 1, Price = 70.00m },
                new CarReservationPricing { Id = 8, CarId = 3, RentalPeriodId = 2, Price = 400.00m },
                new CarReservationPricing { Id = 9, CarId = 3, RentalPeriodId = 3, Price = 1000.00m },
                new CarReservationPricing { Id = 10, CarId = 4, RentalPeriodId = 1, Price = 35.00m },
                new CarReservationPricing { Id = 11, CarId = 4, RentalPeriodId = 2, Price = 110.00m },
                new CarReservationPricing { Id = 12, CarId = 4, RentalPeriodId = 3, Price = 320.00m },
                new CarReservationPricing { Id = 13, CarId = 5, RentalPeriodId = 1, Price = 40.00m },
                new CarReservationPricing { Id = 14, CarId = 5, RentalPeriodId = 2, Price = 110.00m },
                new CarReservationPricing { Id = 15, CarId = 5, RentalPeriodId = 3, Price = 650.00m },
                new CarReservationPricing { Id = 16, CarId = 6, RentalPeriodId = 1, Price = 45.00m },
                new CarReservationPricing { Id = 17, CarId = 6, RentalPeriodId = 2, Price = 130.00m },
                new CarReservationPricing { Id = 18, CarId = 6, RentalPeriodId = 3, Price = 700.00m },
                new CarReservationPricing { Id = 19, CarId = 7, RentalPeriodId = 1, Price = 50.00m },
                new CarReservationPricing { Id = 20, CarId = 7, RentalPeriodId = 2, Price = 220.00m },
                new CarReservationPricing { Id = 21, CarId = 7, RentalPeriodId = 3, Price = 1000.00m },
                new CarReservationPricing { Id = 22, CarId = 8, RentalPeriodId = 1, Price = 30.00m },
                new CarReservationPricing { Id = 23, CarId = 8, RentalPeriodId = 2, Price = 100.00m },
                new CarReservationPricing { Id = 24, CarId = 8, RentalPeriodId = 3, Price = 650.00m },
                new CarReservationPricing { Id = 25, CarId = 9, RentalPeriodId = 1, Price = 80.00m },
                new CarReservationPricing { Id = 26, CarId = 9, RentalPeriodId = 2, Price = 400.00m },
                new CarReservationPricing { Id = 27, CarId = 9, RentalPeriodId = 3, Price = 950.00m },
                new CarReservationPricing { Id = 28, CarId = 10, RentalPeriodId = 1, Price = 20.00m },
                new CarReservationPricing { Id = 29, CarId = 10, RentalPeriodId = 2, Price = 90.00m },
                new CarReservationPricing { Id = 30, CarId = 10, RentalPeriodId = 3, Price = 240.00m },
                new CarReservationPricing { Id = 31, CarId = 11, RentalPeriodId = 1, Price = 15.00m },
                new CarReservationPricing { Id = 32, CarId = 11, RentalPeriodId = 2, Price = 70.00m },
                new CarReservationPricing { Id = 33, CarId = 11, RentalPeriodId = 3, Price = 300.00m }
            );
        }
    }
}
