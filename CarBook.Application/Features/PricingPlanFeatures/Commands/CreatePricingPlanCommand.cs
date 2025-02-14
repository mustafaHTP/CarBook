using MediatR;

namespace CarBook.Application.Features.ReservationPricingFeatures.Commands
{
    public class CreatePricingPlanCommand : IRequest
    {
        public string Name { get; set; }
    }
}
