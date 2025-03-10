using CarBook.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Configurations
{
    public class BannerConfig : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasData(
                new Banner
                {
                    Id = 1,
                    Title = "Fast & Easy Way To Rent A Car",
                    Description = "Rent a car in minutes with CarBook",
                    VideoDescription = "Easy steps for renting a car",
                    VideoUrl = "https://www.youtube.com/watch?v=ZUL0qFMYme8",
                }
            );
        }
    }
}
