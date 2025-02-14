using CarBook.Application.Features.SocialMediaFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Queries
{
    public class GetSocialMediasQuery : IRequest<List<GetSocialMediasQueryResult>>
    {
    }
}
