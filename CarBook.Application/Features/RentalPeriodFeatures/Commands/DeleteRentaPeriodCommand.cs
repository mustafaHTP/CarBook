using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Commands
{
    public class DeleteRentaPeriodCommand : IRequest
    {
        public int Id { get; set; }
    }
}
