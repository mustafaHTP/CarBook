using CarBook.Application.Features.FeatureFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Queries
{
    public class GetAllFeaturesQuery : IRequest<List<GetFeaturesQueryResult>>
    {

    }
}
