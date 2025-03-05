using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Commands
{
    public class CreateRentaPeriodCommand : IRequest
    {
        public string Name { get; set; }
    }
}
