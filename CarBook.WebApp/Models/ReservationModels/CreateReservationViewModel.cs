using CarBook.Domain.Entities;

namespace CarBook.WebApp.Models.ReservationModels
{
    public class CreateReservationViewModel
    {
        public int CarId { get; set; }
        public string CustomerFirstName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }
}
