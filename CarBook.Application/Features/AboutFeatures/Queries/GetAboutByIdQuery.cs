using CarBook.Application.Features.AboutFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Queries
{
    public class GetAboutByIdQuery : IRequest<GetAboutByIdQueryResult>
    {
        public GetAboutByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
