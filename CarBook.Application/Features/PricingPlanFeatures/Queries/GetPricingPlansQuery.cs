using CarBook.Application.Features.PricingPlanFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Queries
{
    public class GetPricingPlansQuery : IRequest<List<GetPricingPlansQueryResult>>
    {
    }
}
