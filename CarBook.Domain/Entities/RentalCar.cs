namespace CarBook.Domain.Entities
{
    public class RentalCar : BaseEntity
    {
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public int CarId { get; set; }
        public Car Car { get; set; } = null!;
        public bool IsAvailable { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
