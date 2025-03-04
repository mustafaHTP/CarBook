using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Commands
{
    public class CreatePricingPlanCommand : IRequest
    {
        public string Name { get; set; }
    }
}
