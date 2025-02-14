using MediatR;

namespace CarBook.Application.Features.ReservationPricingFeatures.Commands
{
    public class DeletePricingPlanCommand : IRequest
    {
        public int Id { get; set; }
    }
}
