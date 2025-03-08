namespace CarBook.Application.Dtos.ReservationDtos
{
    public class CreateReservationDto
    {
        public int CarId { get; set; }
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }
}
