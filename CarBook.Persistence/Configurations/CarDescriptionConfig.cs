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
    public class CarDescriptionConfig : IEntityTypeConfiguration<CarDescription>
    {
        public void Configure(EntityTypeBuilder<CarDescription> builder)
        {
            // Seed Car Descriptions
            builder.HasData(
                new CarDescription { Id = 1, CarId = 1, Description = "A legendary American muscle car, the GT500 boasts supercharged V8 power and a racing heritage rooted in Carroll Shelby’s performance legacy." },
                new CarDescription { Id = 2, CarId = 3, Description = "A compact roadster with a hand-built AMG V8, blending luxury with raw performance in a retractable hardtop design." },
                new CarDescription { Id = 3, CarId = 4, Description = "A groundbreaking hybrid hypercar, the P1 combines F1-inspired aerodynamics with electric-assisted twin-turbo V8 power for extreme performance." },
                new CarDescription { Id = 4, CarId = 5, Description = "A stylish luxury SUV that redefined urban off-roading, known for its sleek design and advanced terrain response system." },
                new CarDescription { Id = 5, CarId = 6, Description = "A high-performance sports sedan, the M3 has dominated track and street alike since the 1980s with its precision engineering and aggressive styling." },
                new CarDescription { Id = 6, CarId = 7, Description = "An exclusive Italian roadster featuring a Ferrari-derived V8, hand-crafted design, and an unmistakable exhaust note." },
                new CarDescription { Id = 7, CarId = 8, Description = "A refined coupe that merges sporty dynamics with cutting-edge technology, positioned between luxury and performance." },
                new CarDescription { Id = 8, CarId = 9, Description = "An off-road icon, the Rubicon is designed for extreme terrain with its rugged build, locking differentials, and legendary 4x4 capabilities." },
                new CarDescription { Id = 9, CarId = 10, Description = "A front-mid-engine sports car developed by AMG, delivering thrilling performance with a powerful twin-turbo V8." },
                new CarDescription { Id = 10, CarId = 11, Description = "A premium compact hatchback that offers advanced tech, efficient performance, and the luxury appeal of the Mercedes-Benz brand." },
                new CarDescription { Id = 11, CarId = 12, Description = "A stylish and compact city car that delivers German engineering, premium features, and agile handling in a small package." }
            );

        }
    }
}
