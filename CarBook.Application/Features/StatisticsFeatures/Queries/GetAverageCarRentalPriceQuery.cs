using CarBook.Application.Features.StatisticsFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Queries
{
    public class GetAverageCarRentalPriceQuery : IRequest<GetAverageCarRentalPriceQueryResult>
    {
        public IEnumerable<string> RentalPeriods { get; set; } = [];
    }
}
