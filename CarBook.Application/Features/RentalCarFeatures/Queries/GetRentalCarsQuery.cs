using CarBook.Application.Features.RentalCarFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.RentalCarFeatures.Queries
{
    public class GetRentalCarsQuery : IRequest<IEnumerable<GetRentalCarsQueryResult>>
    {
        public int? PickUpLocationId { get; set; }
    }
}
