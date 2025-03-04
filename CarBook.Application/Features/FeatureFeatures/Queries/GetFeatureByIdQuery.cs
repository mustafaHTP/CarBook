using CarBook.Application.Features.FeatureFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.FeatureFeatures.Queries
{
    public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFeatureByIdQuery(int id)
        {
            Id = id;
        }
    }
}
