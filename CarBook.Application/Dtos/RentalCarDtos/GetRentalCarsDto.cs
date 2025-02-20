using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Dtos.RentalCarDtos
{
    public class GetRentalCarsDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public bool IsAvailable { get; set; }
    }
}
