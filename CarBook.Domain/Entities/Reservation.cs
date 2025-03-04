using CarBook.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Reservation : BaseEntity
    {
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public int PickUpLocationId { get; set; }
        public Location PickUpLocation { get; set; } = null!;
        public int DropOffLocationId { get; set; }
        public Location DropOffLocation { get; set; } = null!;
    }
}
