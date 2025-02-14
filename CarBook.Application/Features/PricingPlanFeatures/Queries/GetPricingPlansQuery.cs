using CarBook.Application.Features.ReservationPricingFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.ReservationPricingFeatures.Queries
{
    public class GetPricingPlansQuery : IRequest<List<GetPricingPlansQueryResult>>
    {
    }
}
