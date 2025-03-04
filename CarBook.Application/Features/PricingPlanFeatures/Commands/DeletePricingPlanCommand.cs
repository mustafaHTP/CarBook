using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Commands
{
    public class DeletePricingPlanCommand : IRequest
    {
        public int Id { get; set; }
    }
}
