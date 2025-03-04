using CarBook.Application.Features.CarFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Queries
{
    public class GetCarRentalPricingsByIdQuery : IRequest<IEnumerable<GetCarRentalPricingsByIdQueryResult>>
    {
        public int CarId { get; set; }
    }
}
