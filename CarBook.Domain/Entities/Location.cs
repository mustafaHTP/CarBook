namespace CarBook.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; } = null!;
        public List<RentalCar>? RentalCars { get; set; }
        public List<Reservation>? PickUpReservations { get; set; }
        public List<Reservation>? DropOffReservations { get; set; }
    }
}
