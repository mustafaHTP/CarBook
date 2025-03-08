using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Commands
{
    public class CreateRentalPeriodCommand : IRequest
    {
        public string Name { get; set; } = null!;
    }
}
