using MediatR;

namespace CarBook.Application.Features.ReservationFeatures.Commands
{
    public class UpdateReservationCommand : IRequest
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerLastName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int CustomerAge { get; set; }
        public int CustomerDriverLicenseYear { get; set; }
        public string? Description { get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
    }
}
