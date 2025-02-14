using CarBook.Application.Features.CarFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.CarFeatures.Queries
{
    public class GetLast5CarsWithBrandQuery : IRequest<List<GetLast5CarsWithBrandQueryResult>>
    {
    }
}
