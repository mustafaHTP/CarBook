using CarBook.Application.Features.StatisticsFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Queries
{
    public class GetCarCountByTransmissionTypeQuery : IRequest<GetCarCountByTransmissionTypeQueryResult>
    {
        public string? TransmissionTypes { get; set; }
    }
}
