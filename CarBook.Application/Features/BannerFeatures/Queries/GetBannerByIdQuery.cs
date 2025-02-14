using CarBook.Application.Features.BannerFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.BannerFeatures.Queries
{
    public class GetBannerByIdQuery : IRequest<GetBannerByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBannerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
