namespace CarBook.WebApp.Models
{
    public class RentalCarFilterViewModel
    {
        public int? PickUpLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public DateOnly PickUpDate { get; set; }
        public DateOnly DropOffDate { get; set; }
    }
}
