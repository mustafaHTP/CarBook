using MediatR;

namespace CarBook.Application.Features.ReservationFeatures.Commands
{
    public class CreateReservationCommand : IRequest
    {
        public int CarId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }
}
