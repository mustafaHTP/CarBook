using CarBook.Application.Features.PricingPlanFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Queries
{
    public class GetRentalPeriodByIdQuery : IRequest<GetRentalPeriodByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
