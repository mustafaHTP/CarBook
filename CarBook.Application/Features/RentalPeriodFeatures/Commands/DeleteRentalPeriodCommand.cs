using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Commands
{
    public class DeleteRentalPeriodCommand : IRequest
    {
        public int Id { get; set; }
    }
}
