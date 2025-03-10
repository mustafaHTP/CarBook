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
    public class CarFeatureConfig : IEntityTypeConfiguration<CarFeature>
    {
        public void Configure(EntityTypeBuilder<CarFeature> builder)
        {
            builder.HasData(
                // Car 1 (Ford GT500)
                new CarFeature { Id = 1, CarId = 1, FeatureId = 1, Available = true },
                new CarFeature { Id = 2, CarId = 1, FeatureId = 2, Available = true },
                new CarFeature { Id = 3, CarId = 1, FeatureId = 3, Available = false },
                new CarFeature { Id = 4, CarId = 1, FeatureId = 4, Available = true },
                new CarFeature { Id = 5, CarId = 1, FeatureId = 5, Available = true },
                new CarFeature { Id = 6, CarId = 1, FeatureId = 6, Available = true },
                new CarFeature { Id = 7, CarId = 1, FeatureId = 7, Available = false },
                new CarFeature { Id = 8, CarId = 1, FeatureId = 8, Available = true },
                new CarFeature { Id = 9, CarId = 1, FeatureId = 9, Available = false },
                new CarFeature { Id = 10, CarId = 1, FeatureId = 10, Available = true },
                new CarFeature { Id = 11, CarId = 1, FeatureId = 11, Available = true },
                new CarFeature { Id = 12, CarId = 1, FeatureId = 12, Available = true },
                new CarFeature { Id = 13, CarId = 1, FeatureId = 13, Available = false },

                // Car 2 (Mercedes SLK55)
                new CarFeature { Id = 14, CarId = 2, FeatureId = 1, Available = true },
                new CarFeature { Id = 15, CarId = 2, FeatureId = 2, Available = true },
                new CarFeature { Id = 16, CarId = 2, FeatureId = 3, Available = true },
                new CarFeature { Id = 17, CarId = 2, FeatureId = 4, Available = true },
                new CarFeature { Id = 18, CarId = 2, FeatureId = 5, Available = false },
                new CarFeature { Id = 19, CarId = 2, FeatureId = 6, Available = true },
                new CarFeature { Id = 20, CarId = 2, FeatureId = 7, Available = false },
                new CarFeature { Id = 21, CarId = 2, FeatureId = 8, Available = true },
                new CarFeature { Id = 22, CarId = 2, FeatureId = 9, Available = false },
                new CarFeature { Id = 23, CarId = 2, FeatureId = 10, Available = true },
                new CarFeature { Id = 24, CarId = 2, FeatureId = 11, Available = true },
                new CarFeature { Id = 25, CarId = 2, FeatureId = 12, Available = true },
                new CarFeature { Id = 26, CarId = 2, FeatureId = 13, Available = false },

                // Car 3 (McLaren P1)
                new CarFeature { Id = 27, CarId = 3, FeatureId = 1, Available = true },
                new CarFeature { Id = 28, CarId = 3, FeatureId = 2, Available = true },
                new CarFeature { Id = 29, CarId = 3, FeatureId = 3, Available = true },
                new CarFeature { Id = 30, CarId = 3, FeatureId = 4, Available = true },
                new CarFeature { Id = 31, CarId = 3, FeatureId = 5, Available = false },
                new CarFeature { Id = 32, CarId = 3, FeatureId = 6, Available = true },
                new CarFeature { Id = 33, CarId = 3, FeatureId = 7, Available = false },
                new CarFeature { Id = 34, CarId = 3, FeatureId = 8, Available = true },
                new CarFeature { Id = 35, CarId = 3, FeatureId = 9, Available = true },
                new CarFeature { Id = 36, CarId = 3, FeatureId = 10, Available = false },
                new CarFeature { Id = 37, CarId = 3, FeatureId = 11, Available = true },
                new CarFeature { Id = 38, CarId = 3, FeatureId = 12, Available = true },
                new CarFeature { Id = 39, CarId = 3, FeatureId = 13, Available = true },

                // Car 4 (Range Rover Evoque)
                new CarFeature { Id = 40, CarId = 4, FeatureId = 1, Available = true },
                new CarFeature { Id = 41, CarId = 4, FeatureId = 2, Available = true },
                new CarFeature { Id = 42, CarId = 4, FeatureId = 3, Available = false },
                new CarFeature { Id = 43, CarId = 4, FeatureId = 4, Available = true },
                new CarFeature { Id = 44, CarId = 4, FeatureId = 5, Available = true },
                new CarFeature { Id = 45, CarId = 4, FeatureId = 6, Available = true },
                new CarFeature { Id = 46, CarId = 4, FeatureId = 7, Available = true },
                new CarFeature { Id = 47, CarId = 4, FeatureId = 8, Available = false },
                new CarFeature { Id = 48, CarId = 4, FeatureId = 9, Available = true },
                new CarFeature { Id = 49, CarId = 4, FeatureId = 10, Available = true },
                new CarFeature { Id = 50, CarId = 4, FeatureId = 11, Available = true },
                new CarFeature { Id = 51, CarId = 4, FeatureId = 12, Available = true },
                new CarFeature { Id = 52, CarId = 4, FeatureId = 13, Available = false },

                // Car 5 (BMW M3)
                new CarFeature { Id = 53, CarId = 5, FeatureId = 1, Available = true },
                new CarFeature { Id = 54, CarId = 5, FeatureId = 2, Available = true },
                new CarFeature { Id = 55, CarId = 5, FeatureId = 3, Available = true },
                new CarFeature { Id = 56, CarId = 5, FeatureId = 4, Available = false },
                new CarFeature { Id = 57, CarId = 5, FeatureId = 5, Available = true },
                new CarFeature { Id = 58, CarId = 5, FeatureId = 6, Available = true },
                new CarFeature { Id = 59, CarId = 5, FeatureId = 7, Available = false },
                new CarFeature { Id = 60, CarId = 5, FeatureId = 8, Available = true },
                new CarFeature { Id = 61, CarId = 5, FeatureId = 9, Available = false },
                new CarFeature { Id = 62, CarId = 5, FeatureId = 10, Available = true },
                new CarFeature { Id = 63, CarId = 5, FeatureId = 11, Available = true },
                new CarFeature { Id = 64, CarId = 5, FeatureId = 12, Available = true },
                new CarFeature { Id = 65, CarId = 5, FeatureId = 13, Available = true },

                // Car 6 (Alfa Romeo 8C Spider)
                new CarFeature { Id = 66, CarId = 6, FeatureId = 1, Available = true },
                new CarFeature { Id = 67, CarId = 6, FeatureId = 2, Available = true },
                new CarFeature { Id = 68, CarId = 6, FeatureId = 3, Available = false },
                new CarFeature { Id = 69, CarId = 6, FeatureId = 4, Available = true },
                new CarFeature { Id = 70, CarId = 6, FeatureId = 5, Available = true },
                new CarFeature { Id = 71, CarId = 6, FeatureId = 6, Available = true },
                new CarFeature { Id = 72, CarId = 6, FeatureId = 7, Available = true },
                new CarFeature { Id = 73, CarId = 6, FeatureId = 8, Available = true },
                new CarFeature { Id = 74, CarId = 6, FeatureId = 9, Available = false },
                new CarFeature { Id = 75, CarId = 6, FeatureId = 10, Available = true },
                new CarFeature { Id = 76, CarId = 6, FeatureId = 11, Available = true },
                new CarFeature { Id = 77, CarId = 6, FeatureId = 12, Available = false },
                new CarFeature { Id = 78, CarId = 6, FeatureId = 13, Available = true },

                // Car 7 (Mercedes CLE 300)
                new CarFeature { Id = 79, CarId = 7, FeatureId = 1, Available = true },
                new CarFeature { Id = 80, CarId = 7, FeatureId = 2, Available = true },
                new CarFeature { Id = 81, CarId = 7, FeatureId = 3, Available = true },
                new CarFeature { Id = 82, CarId = 7, FeatureId = 4, Available = true },
                new CarFeature { Id = 83, CarId = 7, FeatureId = 5, Available = true },
                new CarFeature { Id = 84, CarId = 7, FeatureId = 6, Available = true },
                new CarFeature { Id = 85, CarId = 7, FeatureId = 7, Available = false },
                new CarFeature { Id = 86, CarId = 7, FeatureId = 8, Available = true },
                new CarFeature { Id = 87, CarId = 7, FeatureId = 9, Available = true },
                new CarFeature { Id = 88, CarId = 7, FeatureId = 10, Available = false },
                new CarFeature { Id = 89, CarId = 7, FeatureId = 11, Available = true },
                new CarFeature { Id = 90, CarId = 7, FeatureId = 12, Available = true },
                new CarFeature { Id = 91, CarId = 7, FeatureId = 13, Available = false },

                // Car 8 (Jeep Wrangler Rubicon)
                new CarFeature { Id = 92, CarId = 8, FeatureId = 1, Available = true },
                new CarFeature { Id = 93, CarId = 8, FeatureId = 2, Available = true },
                new CarFeature { Id = 94, CarId = 8, FeatureId = 3, Available = false },
                new CarFeature { Id = 95, CarId = 8, FeatureId = 4, Available = true },
                new CarFeature { Id = 96, CarId = 8, FeatureId = 5, Available = false },
                new CarFeature { Id = 97, CarId = 8, FeatureId = 6, Available = true },
                new CarFeature { Id = 98, CarId = 8, FeatureId = 7, Available = false },
                new CarFeature { Id = 99, CarId = 8, FeatureId = 8, Available = true },
                new CarFeature { Id = 100, CarId = 8, FeatureId = 9, Available = true },
                new CarFeature { Id = 101, CarId = 8, FeatureId = 10, Available = true },
                new CarFeature { Id = 102, CarId = 8, FeatureId = 11, Available = true },
                new CarFeature { Id = 103, CarId = 8, FeatureId = 12, Available = false },
                new CarFeature { Id = 104, CarId = 8, FeatureId = 13, Available = true },

                // Car 9 (Mercedes GT Coupe)
                new CarFeature { Id = 105, CarId = 9, FeatureId = 1, Available = true },
                new CarFeature { Id = 106, CarId = 9, FeatureId = 2, Available = true },
                new CarFeature { Id = 107, CarId = 9, FeatureId = 3, Available = false },
                new CarFeature { Id = 108, CarId = 9, FeatureId = 4, Available = true },
                new CarFeature { Id = 109, CarId = 9, FeatureId = 5, Available = false },
                new CarFeature { Id = 110, CarId = 9, FeatureId = 6, Available = true },
                new CarFeature { Id = 111, CarId = 9, FeatureId = 7, Available = false },
                new CarFeature { Id = 112, CarId = 9, FeatureId = 8, Available = true },
                new CarFeature { Id = 113, CarId = 9, FeatureId = 9, Available = true },
                new CarFeature { Id = 114, CarId = 9, FeatureId = 10, Available = false },
                new CarFeature { Id = 115, CarId = 9, FeatureId = 11, Available = true },
                new CarFeature { Id = 116, CarId = 9, FeatureId = 12, Available = false },
                new CarFeature { Id = 117, CarId = 9, FeatureId = 13, Available = true },

                // Car 10 (Mercedes A180)
                new CarFeature { Id = 118, CarId = 10, FeatureId = 1, Available = true },
                new CarFeature { Id = 119, CarId = 10, FeatureId = 2, Available = true },
                new CarFeature { Id = 120, CarId = 10, FeatureId = 3, Available = true },
                new CarFeature { Id = 121, CarId = 10, FeatureId = 4, Available = false },
                new CarFeature { Id = 122, CarId = 10, FeatureId = 5, Available = true },
                new CarFeature { Id = 123, CarId = 10, FeatureId = 6, Available = true },
                new CarFeature { Id = 124, CarId = 10, FeatureId = 7, Available = false },
                new CarFeature { Id = 125, CarId = 10, FeatureId = 8, Available = true },
                new CarFeature { Id = 126, CarId = 10, FeatureId = 9, Available = true },
                new CarFeature { Id = 127, CarId = 10, FeatureId = 10, Available = true },
                new CarFeature { Id = 128, CarId = 10, FeatureId = 11, Available = true },
                new CarFeature { Id = 129, CarId = 10, FeatureId = 12, Available = false },
                new CarFeature { Id = 130, CarId = 10, FeatureId = 13, Available = true },

                 // Car 11 (Audi A1)
                 new CarFeature { Id = 131, CarId = 11, FeatureId = 1, Available = true },
                new CarFeature { Id = 132, CarId = 11, FeatureId = 2, Available = true },
                new CarFeature { Id = 133, CarId = 11, FeatureId = 3, Available = true },
                new CarFeature { Id = 134, CarId = 11, FeatureId = 4, Available = true },
                new CarFeature { Id = 135, CarId = 11, FeatureId = 5, Available = false },
                new CarFeature { Id = 136, CarId = 11, FeatureId = 6, Available = true },
                new CarFeature { Id = 137, CarId = 11, FeatureId = 7, Available = false },
                new CarFeature { Id = 138, CarId = 11, FeatureId = 8, Available = true },
                new CarFeature { Id = 139, CarId = 11, FeatureId = 9, Available = false },
                new CarFeature { Id = 140, CarId = 11, FeatureId = 10, Available = true },
                new CarFeature { Id = 141, CarId = 11, FeatureId = 11, Available = true },
                new CarFeature { Id = 142, CarId = 11, FeatureId = 12, Available = true },
                new CarFeature { Id = 143, CarId = 11, FeatureId = 13, Available = false }

                );

        }
    }
}
