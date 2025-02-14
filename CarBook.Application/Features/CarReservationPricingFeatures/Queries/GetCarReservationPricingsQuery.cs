using CarBook.Application.Features.CarReservationPricingFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarReservationPricingFeatures.Queries
{
    public class GetCarReservationPricingsQuery : IRequest<List<GetCarReservationPricingsQueryResult>>
    {
    }
}
