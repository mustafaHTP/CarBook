using CarBook.Domain.Entities;

namespace CarBook.WebApp.Models
{
    public class RentalCarsViewModel
    {
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public bool IsAvailable { get; set; }
    }
}
