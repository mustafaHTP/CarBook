namespace CarBook.Application.Dtos.RentalCarDtos
{
    public class RentalCarFilterDto
    {
        public int? PickUpLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public DateTime? PickUpDate { get; set; }
        public DateTime? DropOffDate { get; set; }
    }
}
