using CarBook.Application.Features.PricingPlanFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Queries
{
    public class GetPricingPlanByIdQuery : IRequest<GetPricingPlanByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
