using MediatR;

namespace CarBook.Application.Features.ReservationFeatures.Commands
{
    public class DeleteReservationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
