using CarBook.Application.Features.ReservationPricingFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.ReservationPricingFeatures.Queries
{
    public class GetPricingPlanByIdQuery : IRequest<GetPricingPlanByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
