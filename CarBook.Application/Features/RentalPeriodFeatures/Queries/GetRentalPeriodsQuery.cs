using CarBook.Application.Features.PricingPlanFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Queries
{
    public class GetRentalPeriodsQuery : IRequest<List<GetRentalPeriodsQueryResult>>
    {
    }
}
