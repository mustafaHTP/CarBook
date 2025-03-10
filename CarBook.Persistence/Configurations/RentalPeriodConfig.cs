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
    public class RentalPeriodConfig : IEntityTypeConfiguration<RentalPeriod>
    {
        public void Configure(EntityTypeBuilder<RentalPeriod> builder)
        {
            builder.HasData(
                new RentalPeriod
                {
                    Id = 1,
                    Name = "Hour",
                },
                new RentalPeriod
                {
                    Id = 2,
                    Name = "Day",
                },
                new RentalPeriod
                {
                    Id = 3,
                    Name = "Week",
                }
             );
        }
    }
}
