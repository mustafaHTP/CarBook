using CarBook.Application.Features.CarReservationPricingFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarReservationPricingFeatures.Queries
{
    public class GetCarReservationPricingsWithDayPricingPlanQuery : IRequest<List<GetCarReservationPricingsWithDayPricingPlanQueryResult>>
    {
    }
}
