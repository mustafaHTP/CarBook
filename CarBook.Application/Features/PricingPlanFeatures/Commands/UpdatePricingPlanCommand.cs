using MediatR;

namespace CarBook.Application.Features.ReservationPricingFeatures.Commands
{
    public class UpdatePricingPlanCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
